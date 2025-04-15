import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import initAuth from "../../Redux/authSlice";

const GoogleCallbackPage = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    useEffect(() => {
        const urlParams = new URLSearchParams(window.location.search);
        const accessToken = urlParams.get('accessToken');
        const refreshToken = urlParams.get('refreshToken');

        if (accessToken && refreshToken) {
            localStorage.setItem('accessToken', accessToken);
            localStorage.setItem('refreshToken', refreshToken);

            dispatch(initAuth()); // ✅ подгружаем данные пользователя
            navigate('/courses');
        } else {
            console.error('Токены не получены.');
            navigate('/login');
        }
    }, [navigate, dispatch]);

    return <div>Завантаження...</div>;
};

export default GoogleCallbackPage;