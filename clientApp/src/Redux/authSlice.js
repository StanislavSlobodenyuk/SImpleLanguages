// imports
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { registerUser, loginUser, logoutUser, refreshTokens as apiRefreshTokens, } from "../api/authenticationApi";

// create tokens

const accessToken = localStorage.getItem('accessToken');
const refreshToken = localStorage.getItem('refreshToken');

const initialState = {
    isAuthenticated: false,
    userId: null,
    accessToken: localStorage.getItem('accessToken') || null,
    refreshToken: localStorage.getItem('refreshToken') || null,
    loading: false,
    error: null
};

// login Thunk
export const loginThunk = createAsyncThunk(
    'auth/login',
    async (formData, { rejectWithValue }) => {
        try {
            const data = await loginUser(formData);
            return data;
        } catch (err) {
            return rejectWithValue(err);
        }
    }
);

// register Thunk
export const registerThunk = createAsyncThunk(
    'auth/register',
    async (formData, { rejectWithValue }) => {
        try {
            const data = await registerUser(formData);
            return data;
        } catch (err) {
            return rejectWithValue(err);
        }
    }
)

// logout  thunk
export const logoutThunk = createAsyncThunk(
    'auth/logout',
    async (_, { dispatch }) => {
        await logoutUser();
        dispatch(logout());
    }
);

// refresh thunk
export const refreshThunk = createAsyncThunk(
    'auth/refresh',
    async ({ accessToken, refreshToken }, { rejectWithValue }) => {
        try {
            const data = await apiRefreshTokens({ accessToken, refreshToken });
            return data;
        } catch (error) {
            return rejectWithValue(error);
        }
    }
)

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        logout(state) {
            state.isAuthenticated = false;
            state.userId = null;
            state.accessToken = null;
            state.refreshToken = null;
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
        }
    },
    extraReducers: builder => {
        builder
            // LOGIN
            .addCase(loginThunk.pending, state => {
                state.loading = true;
                state.error = null;
            })
            .addCase(loginThunk.fulfilled, (state, { payload }) => {
                state.loading = false;
                state.isAuthenticated = true;
                state.userId = payload.userId;
                state.accessToken = payload.accessToken;
                state.refreshToken = payload.refreshToken;
                localStorage.setItem('accessToken', payload.accessToken);
                localStorage.setItem('refreshToken', payload.refreshToken);
            })
            .addCase(loginThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })

            // REGISTER 
            .addCase(registerThunk.pending, state => {
                state.loading = true;
                state.error = null;
            })
            .addCase(registerThunk.fulfilled, (state, { payload }) => {
                state.loading = false;
                state.isAuthenticated = true;
                state.userId = payload.userId;
                state.accessToken = payload.accessToken;
                state.refreshToken = payload.refreshToken;
                localStorage.setItem('accessToken', payload.accessToken);
                localStorage.setItem('refreshToken', payload.refreshToken);
            })
            .addCase(registerThunk.rejected, (state, { payload }) => {
                state.loading = false;
                state.error = payload;
            })

            // REFRESH
            .addCase(refreshThunk.fulfilled, (state, { payload }) => {
                state.accessToken = payload.accessToken;
                state.refreshToken = payload.refreshToken;
                localStorage.setItem('accessToken', payload.accessToken);
                localStorage.setItem('refreshToken', payload.refreshToken);
            })
            .addCase(refreshThunk.rejected, (state, { payload }) => {
                state.error = payload;
            });
    }
});

export const { logout } = authSlice.actions;
export default authSlice.reducer;