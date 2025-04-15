import { Link } from 'react-router-dom';
import { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { loginThunk } from "../../Redux/authSlice";
import { useNavigate } from "react-router-dom";
import GoogleAuthenticatedButton from "../GoogleAuth/GoogleAuthenticatedButton";
import Button from "../../components/Common/Button/Button";
import styles from "../authorizationForm.module.less";

function LoginPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { loading, isAuthenticated } = useSelector((state) => state.auth);

    const [error, setError] = useState('');

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

    const validateLoginData = () => {
        const { usernameOrEmail, password } = loginData;

        if (!usernameOrEmail || !password) {
            setError("Не всі поля заповнені");
            return false;
        }

        const forbiddenCharsRegex = /['"<>;(){}]/;
        if (
            forbiddenCharsRegex.test(usernameOrEmail) ||
            forbiddenCharsRegex.test(password)
        ) {
            setError("Одне з ваших полів містить заборонені символи");
            return false;
        }

        setError("");
        return true;
    };

    const handleLoginClick = () => {
        if (!validateLoginData()) return;
        dispatch(loginThunk(loginData));
    };

    return (
        <div className={`${styles.authorizationForm} ${styles.authorizationForm_logic}`}>
            <div className={styles.formContainer}>
                <div className={styles.form}>
                    <h2 className={styles.formTitle}>Вхід</h2>
                    <input
                        type="text"
                        name="usernameOrEmail"
                        value={loginData.usernameOrEmail}
                        onChange={handleUserDataLoginChange}
                        placeholder="Email"
                        className={styles.formInput}
                    />
                    <input
                        type="password"
                        name="password"
                        value={loginData.password}
                        onChange={handleUserDataLoginChange}
                        placeholder="Пароль"
                        className={styles.formInput}
                    />

                    {error && (
                        <div className={styles.formError}>
                            {error}
                        </div>
                    )}

                    <div className={styles.formButton}>
                        <Button click={handleLoginClick} type="button">Увійти</Button>
                    </div>
                </div>
            </div>

            <div className={styles.swapAuthLink}>
                <Link to="/register">Ще не маєте аккаунту? Зареєструватися</Link>
            </div>

            <div className={styles.exterlaAuthorization}>
                <GoogleAuthenticatedButton />
            </div>
        </div>
    );
};

export default LoginPage;