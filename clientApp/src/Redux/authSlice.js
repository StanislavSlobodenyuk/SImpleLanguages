import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import {
    registerUser,
    loginUser,
    logoutUser,
    refreshTokens as apiRefreshTokens,
} from "../api/authenticationApi";
import { decodeToken } from "./decodeToken";

const initialState = {
    isAuthenticated: false,
    userId: null,
    userEmail: null,
    userName: null,
    role: null,
    accessToken: localStorage.getItem("accessToken") || null,
    refreshToken: localStorage.getItem("refreshToken") || null,
    loading: false,
    error: null,
};

const mapClaims = (decoded) => ({
    userId: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
    userName: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
    email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
    role: decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
    firstName: decoded.firstName,
    lastName: decoded.lastName,
    userIcon: decoded.userIcon,
});

function saveUserData(userInfo, data) {
    localStorage.setItem("user", JSON.stringify(userInfo));
    localStorage.setItem("accessToken", data.accessToken);
    localStorage.setItem("refreshToken", data.refreshToken);
    localStorage.setItem("authData", JSON.stringify({ accessToken: data.accessToken, refreshToken: data.refreshToken }))
}

// Login thunk
export const loginThunk = createAsyncThunk(
    "auth/login",
    async (formData, { rejectWithValue }) => {
        try {
            const data = await loginUser(formData);
            const accessToken = data?.data?.accessToken;
            const user = mapClaims(decodeToken(accessToken));

            return { ...data, user };
        } catch (err) {
            return rejectWithValue(err);
        }
    }
);

// Register thunk
export const registerThunk = createAsyncThunk(
    "auth/register",
    async (formData, { rejectWithValue }) => {
        try {
            const data = await registerUser(formData);
            const accessToken = data?.data?.accessToken;
            const user = mapClaims(decodeToken(accessToken));

            return { ...data, user };
        } catch (err) {
            return rejectWithValue(err);
        }
    }
);

// Refresh thunk
export const refreshThunk = createAsyncThunk(
    "auth/refresh",
    async ({ accessToken, refreshToken }, { rejectWithValue }) => {
        try {
            const data = await apiRefreshTokens(accessToken, refreshToken);

            const newAccessToken = data?.data?.accessToken;
            const user = mapClaims(decodeToken(accessToken));

            return { ...data, user };
        } catch (error) {
            console.error('Error in refreshThunk:', error);  // Логирование ошибки
            return rejectWithValue(error);
        }
    }
);

// Logout thunk
export const logoutThunk = createAsyncThunk(
    "auth/logout",
    async (_, { dispatch }) => {
        await logoutUser();
        dispatch(logout());
    }
);

// initAuth thunk
export const initAuthThunk = createAsyncThunk(
    "auth/initAuth",
    async (_, { dispatch, rejectWithValue }) => {
        try {
            const accessToken = localStorage.getItem("accessToken");
            const refreshToken = localStorage.getItem("refreshToken");

            if (!accessToken || !refreshToken) {
                return rejectWithValue("No token found");
            }

            const user = mapClaims(decodeToken(accessToken));

            const exp = user.exp * 1000;
            const now = Date.now();

            if (exp < now) {
                const refreshResult = await dispatch(refreshThunk({ accessToken, refreshToken }));

                if (refreshResult.meta.requestStatus === 'rejected') {
                    return rejectWithValue("refresh failed");
                }

                return refreshResult.payload;
            }

            const data = {
                accessToken: accessToken,
                refreshToken: refreshToken
            };

            return { data, user };
        } catch (error) {
            return rejectWithValue("InvalidToken");
        }
    }
)

const authSlice = createSlice({
    name: "auth",
    initialState,
    // Logout =======================================================================
    reducers: {
        logout(state) {
            state.isAuthenticated = false;
            state.userId = null;
            state.userEmail = null;
            state.userName = null;
            state.accessToken = null;
            state.refreshToken = null;
            localStorage.removeItem("user");
            localStorage.removeItem("authData");
            localStorage.removeItem("accessToken");
            localStorage.removeItem("refreshToken");
        },
    },
    // Logout =======================================================================
    extraReducers: (builder) => {
        builder
            .addCase(loginThunk.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            // login =================================================================
            .addCase(loginThunk.fulfilled, (state, { payload }) => {
                const { data, user } = payload;

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = user.userId;
                state.userEmail = user.userEmail;
                state.userName = user.userName;
                state.role = user.role;
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                saveUserData(user, data);
            })
            .addCase(loginThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })
            // login ==================================================================

            // register ===============================================================
            .addCase(registerThunk.fulfilled, (state, { payload }) => {
                const { data, user } = payload;

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = user.userId;
                state.userEmail = user.userEmail;
                state.userName = user.userName;
                state.role = user.role;
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                saveUserData(user, data);
            })
            .addCase(registerThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })
            // register ===================================================================
            // refresh ===================================================================
            .addCase(refreshThunk.fulfilled, (state, { payload }) => {
                const { data, user } = payload;

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = user.userId;
                state.userEmail = user.userEmail;
                state.userName = user.userName;
                state.role = user.role;
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                saveUserData(user, data);
            })
            .addCase(refreshThunk.rejected, (state, { payload }) => {
                state.error = payload;
            })
            // refresh ===================================================================
            // initAuth ================================================================== 
            .addCase(initAuthThunk.fulfilled, (state, { payload }) => {
                const { data, user } = payload;

                state.isAuthenticated = true;
                state.userId = user.userId;
                state.userEmail = user.userEmail;
                state.userName = user.userName;

                saveUserData(user, data);
                state.isAuthenticated = true;

                saveUserData(user, data);
            })
            .addCase(initAuthThunk.rejected, (state) => {
                state.isAuthenticated = false;
                state.userId = null;
                state.userEmail = null;
                state.userName = null;
                state.role = null;
                state.accessToken = null;
                state.refreshToken = null;
            });
        // initAuth ==================================================================
    },
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;