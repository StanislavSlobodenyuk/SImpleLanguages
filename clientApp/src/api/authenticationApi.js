import api from './api';

// POST /login
export const loginUser = async (formData) => {
    try {
        const { data } = await api.post("/api/Authorization/login", formData);
        console.log('login:', data);
        return data;
    } catch (error) {
        console.error('Login error:', error.response?.data || error);
        throw error.response?.data || error;
    }
};

// POST /register
export const registerUser = async (formData) => {
    try {
        const { data } = await api.post("/api/Authorization/register", formData);
        console.log('register:', data);
        return data;
    } catch (error) {
        console.error('Register error:', error.response?.data || error);
        throw error.response?.data || error;
    }
};

// Redirect to Google OAuth
export const startGoogleLogin = () => {
    window.location.href = `${api.defaults.baseURL}/signin-google`;
    console.log("Redirecting to Google login...");
};

// POST /logout
export const logoutUser = async () => {
    try {
        await api.post("/api/Authorization/logout");
    } catch (error) {
        console.error('Logout error:', error.response?.data || error);
        throw error;
    }
};

// POST /refresh
export const refreshTokens = async (formData) => {
    try {
        const { data } = await api.post("/api/Authorization/refresh", formData);
        console.log('refresh:', data);
        return data;
    } catch (error) {
        console.error('Refresh error:', error.response?.data || error);
        throw error.response?.data || error;
    }
};
