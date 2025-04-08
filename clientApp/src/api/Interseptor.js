import axios from "axios";
import { refreshThunk, logoutThunk } from "../Redux/authSlice";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000',
    headers: { 'Content-Type': 'application/json' }
})

api.interceptors.request.use(
    (config) => {
        const accessToken = localStorage.getItem('accessToken');
        if (accessToken) {
            config.headers.Authorization = `Bearer ${accessToken}`;
        }

        return config;
    },
    (error) => Promise.reject(error)
);

api.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        if (error.response?.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;

            const authData = JSON.parse(localStorage.getItem('authData'));
            const accessToken = authData?.accessToken;
            const refreshToken = authData?.refreshToken;

            if (!refreshToken) {
                localStorage.clear();
                window.location.reload();
                return Promise.reject(error);
            }

            try {
                const refreshResult = await refreshThunk({ accessToken, refreshToken })(
                    () => { }, // пустой dispatch, тк мы не используем store
                    () => { }, // пустой getState
                    undefined
                );

                if (refreshResult.meta.requestStatus === 'fulfilled') {
                    const newAccessToken = refreshResult.payload.accessToken;

                    localStorage.setItem('accessToken', newAccessToken);
                    localStorage.setItem('authData', JSON.stringify({
                        accessToken: newAccessToken,
                        refreshToken: refreshToken
                    }));

                    originalRequest.headers.Authorization = `Bearer ${newAccessToken}`;
                    return api(originalRequest);
                } else {
                    localStorage.clear();
                    window.location.reload();
                    return Promise.reject(error);
                }
            } catch (err) {
                localStorage.clear();
                window.location.reload();
                return Promise.reject(err);
            }
        }
        return Promise.reject(error);
    }
)

export default api;