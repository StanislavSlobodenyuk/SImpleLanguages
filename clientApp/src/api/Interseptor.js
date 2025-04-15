import axios from "axios";
import { refreshThunk } from "../Redux/authSlice";

// Создаём axios экземпляр
const api = axios.create({
    baseURL: import.meta.env.VITE_API_URL || 'http://localhost:5000',
    headers: { 'Content-Type': 'application/json' }
});

// Интерсептор запроса (добавление токена в заголовки)
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

// Интерсептор ответа (обработка 401 ошибок и обновление токена)
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
                    () => { }, // Пустой dispatch
                    () => { }, // Пустой getState
                    undefined
                );

                if (refreshResult.meta.requestStatus === 'fulfilled') {
                    const newAccessToken = refreshResult.payload.data.accessToken;
                    const newRefreshToken = refreshResult.payload.data.refreshToken;

                    localStorage.setItem('accessToken', newAccessToken);
                    localStorage.setItem('refreshToken', newRefreshToken);
                    localStorage.setItem('authData', JSON.stringify({
                        accessToken: newAccessToken,
                        refreshToken: newRefreshToken
                    }));

                    originalRequest.headers.Authorization = `Bearer ${localStorage.getItem('accessToken')}`;
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
);

export default api;
