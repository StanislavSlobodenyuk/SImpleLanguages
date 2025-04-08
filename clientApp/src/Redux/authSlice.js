import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import api from "../api/Interseptor";
import {
    registerUser,
    loginUser,
    logoutUser,
    refreshTokens as apiRefreshTokens,
} from "../api/authenticationApi";
import { decodeToken } from "./decodeToken";
import { json } from "react-router-dom";

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

// Login thunk
export const loginThunk = createAsyncThunk(
    "auth/login",
    async (formData, { rejectWithValue }) => {
        try {
            const data = await loginUser(formData);
            const accessToken = data?.data?.accessToken;
            const userInfo = decodeToken(accessToken);

            return { ...data, userInfo };
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
            const userInfo = decodeToken(accessToken);

            return { ...data, userInfo };
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
            const userInfo = decodeToken(newAccessToken);

            return { ...data, userInfo };
        } catch (error) {
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

            const userInfo = decodeToken(accessToken);
            const exp = userInfo.exp * 1000;
            const now = Date.now();

            if (exp < now) {
                const refreshResult = await dispatch(refreshThunk({ accessToken, refreshToken }));

                if (refreshResult.meta.requestStatus === 'rejected') {
                    return rejectWithValue("refresh failed");
                }

                return refreshResult.payload;
            }

            return { accessToken, refreshToken, userInfo };
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
                const { data, userInfo } = payload;

                console.log(userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"])

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
                state.userEmail = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
                state.userName = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
                state.role = userInfo["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                localStorage.setItem("accessToken", data.accessToken);
                localStorage.setItem("refreshToken", data.refreshToken);
                localStorage.setItem("authData", JSON.stringify({ accessToken: data.accessToken, refreshToken: data.refreshToken }))
            })
            .addCase(loginThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })
            // login ==================================================================

            // register ===============================================================
            .addCase(registerThunk.fulfilled, (state, { payload }) => {
                const { data, userInfo } = payload;

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
                state.userEmail = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
                state.userName = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
                state.role = userInfo["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                localStorage.setItem("accessToken", data.accessToken);
                localStorage.setItem("refreshToken", data.refreshToken);
                localStorage.setItem("authData", JSON.stringify({ accessToken: data.accessToken, refreshToken: data.refreshToken }))
            })
            .addCase(registerThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })
            // register ===================================================================
            // refresh ===================================================================
            .addCase(refreshThunk.fulfilled, (state, { payload }) => {
                const { data, userInfo } = payload;

                state.loading = false;
                state.isAuthenticated = true;
                state.userId = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
                state.userEmail = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
                state.userName = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
                state.role = userInfo["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                state.accessToken = data.accessToken;
                state.refreshToken = data.refreshToken;

                localStorage.setItem("accessToken", data.accessToken);
                localStorage.setItem("refreshToken", data.refreshToken);
                localStorage.setItem("authData", JSON.stringify({ accessToken: data.accessToken, refreshToken: data.refreshToken }))
            })
            .addCase(refreshThunk.rejected, (state, { payload }) => {
                state.error = payload;
            })
            // refresh ===================================================================
            // initAuth ================================================================== 
            .addCase(initAuthThunk.fulfilled, (state, { payload }) => {
                const { accessToken, refreshToken, userInfo } = payload;

                state.isAuthenticated = true;
                state.userId = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
                state.userEmail = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
                state.userName = userInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
                state.role = userInfo["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

                localStorage.setItem("accessToken", accessToken);
                localStorage.setItem("refreshToken", refreshToken);
                localStorage.setItem("authData", JSON.stringify({ accessToken: accessToken, refreshToken: refreshToken }))
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