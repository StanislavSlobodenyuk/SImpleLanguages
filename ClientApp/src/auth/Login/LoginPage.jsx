import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { loginThunk } from "../../Redux/authSlice";
import { useNavigate } from "react-router-dom";
import GoogleAuthenticatedButton from "../GoogleAuth/GoogleAuthenticatedButton";

function LoginPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { loading, error, isAuthenticated } = useSelector((state) => state.auth);

    const [loginData, setLoginData] = useState({
        usernameOrEmail: '',
        password: ''
    });

    useEffect(() => {
        if (isAuthenticated) {
            navigate('/');
        }
    }, [isAuthenticated, navigate]);

    const handleUserDataLoginChange = (e) => {
        setLoginData({ ...loginData, [e.target.name]: e.target.value });
    }

    const hendleValidateLogin = () => {
        if (!loginData.password || !loginData.usernameOrEmail) {
            console.log("Не всі поля заповнені");
            return
        }

        dispatch(loginThunk(loginData));
    }

    return (
        <div>
            <h2>Вхід</h2>
            <form>
                <input
                    type="text"
                    name="usernameOrEmail"
                    value={loginData.usernameOrEmail}
                    onChange={handleUserDataLoginChange}
                    placeholder="Email"
                />
                <input
                    type="password"
                    name="password"
                    value={loginData.password}
                    onChange={handleUserDataLoginChange}
                    placeholder="Пароль"
                />
                <button onClick={hendleValidateLogin}>Увійти</button>
            </form>

            <button onClick={() => navigate('/register')}>Ще не маєте аккаунту? Зареєструйтеся.</button>
            <GoogleAuthenticatedButton />
        </div>
    );
};

export default LoginPage;