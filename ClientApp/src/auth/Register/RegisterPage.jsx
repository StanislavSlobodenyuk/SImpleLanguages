import { Link } from 'react-router-dom';
import { useEffect, useState } from "react";
import styles from "../authorizationForm.module.less";
import { useDispatch, useSelector } from "react-redux";
import { registerThunk } from "../../Redux/authSlice.js";
import { useNavigate } from "react-router-dom";
import GoogleAuthenticatedButton from "../GoogleAuth/GoogleAuthenticatedButton";
import { reverseLanguageMapping, reverseLevelMapping } from '../../mapping/Mappinig.js';
import Button from "../../components/Common/Button/Button"

function RegisterPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { isAuthenticated } = useSelector(state => state.auth);

    const [error, setError] = useState('');
    const [step, setStep] = useState(1);
    const [userData, setUserData] = useState({
        userName: '',
        userEmail: '',
        password: '',
        confirmedPassword: ''
    });

    const [languageData, setLanguageData] = useState({
        nativeLanguage: '',
        targetLanguage: '',
        levelTargetLanguage: ''
    });

    useEffect(() => {
        if (isAuthenticated) {
            navigate('/');
        }
    }, [isAuthenticated, navigate]);

    const handleUserDataChange = (e) => {
        setUserData({ ...userData, [e.target.name]: e.target.value });
    };

    const handleLanguageDataChange = (e) => {
        setLanguageData({ ...languageData, [e.target.name]: e.target.value });
    };

    const handleValidateStep1 = () => {
        const { userEmail, userName, password, confirmedPassword } = userData;

        if (password !== confirmedPassword) {
            setError("Паролі не збігаються");
            return;
        }

        if (!password || !userEmail || !userName || !confirmedPassword) {
            setError("Не всі поля заповнені");
            return;
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(userEmail)) {
            setError("Невірний формат пошти");
            return;
        }

        if (userName.length > 50) {
            setError("Ім’я повинно бути не більше 50 символів");
            return;
        }

        const forbiddenCharsRegex = /['"<>;(){}]/;
        if (
            forbiddenCharsRegex.test(userEmail) ||
            forbiddenCharsRegex.test(userName) ||
            forbiddenCharsRegex.test(password)
        ) {
            setError("Одне з ваших полів містить заборонені символи");
            return;
        }

        setError("");
        setStep(2);
    };

    const handleValidateStep2 = (e) => {
        e.preventDefault();
        if (!languageData.nativeLanguage || !languageData.targetLanguage || !languageData.levelTargetLanguage) {
            setError("Не всі поля заповнені");
            return;
        }

        const registerData = {
            ...userData,
            nativeLanguage: reverseLanguageMapping[languageData.nativeLanguage],
            targetLanguage: reverseLanguageMapping[languageData.targetLanguage],
            levelTargetLanguage: reverseLevelMapping[languageData.levelTargetLanguage],
        };

        setError("");
        dispatch(registerThunk(registerData));
    };

    return (
        <>
            <div className={styles.authorizationForm}>
                {step === 1 && (
                    <div className={styles.formContainer}>
                        <form className={styles.form}>
                            <h2 className={styles.formTitle}>Крок 1</h2>
                            <input
                                type="text"
                                name="userName"
                                value={userData.userName}
                                onChange={handleUserDataChange}
                                placeholder="User name"
                                className={styles.formInput}
                            />
                            <input
                                type="email"
                                name="userEmail"
                                value={userData.userEmail}
                                onChange={handleUserDataChange}
                                placeholder="Email"
                                className={styles.formInput}
                            />
                            <input
                                type="password"
                                name="password"
                                value={userData.password}
                                onChange={handleUserDataChange}
                                placeholder="Password"
                                className={styles.formInput}
                            />
                            <input
                                type="password"
                                name="confirmedPassword"
                                value={userData.confirmedPassword}
                                onChange={handleUserDataChange}
                                placeholder="Confirm password"
                                className={styles.formInput}
                            />
                            <div className={styles.formButton}>
                                <Button click={handleValidateStep1} type='button'>Далі</Button>
                            </div>
                        </form>
                    </div>
                )}

                {step === 2 && (
                    <div className={styles.formContainer}>
                        <h2 lassName={styles.formTitle}>Крок 2</h2>
                        <form className={styles.form}>
                            <select className={styles.formSelect} name="nativeLanguage" value={languageData.nativeLanguage} onChange={handleLanguageDataChange}>
                                <option value="">Оберіть мову</option>
                                <option value="1">Англійська</option>
                                <option value="2">Українська</option>
                                <option value="3">Польська</option>
                                <option value="4">Чешська</option>
                            </select>
                            <select className={styles.formSelect} name="targetLanguage" value={languageData.targetLanguage} onChange={handleLanguageDataChange}>
                                <option value="">Оберіть мову</option>
                                <option value="1">Англійська</option>
                                <option value="2">Українська</option>
                                <option value="3">Польська</option>
                                <option value="4">Чешська</option>
                            </select>
                            <select className={styles.formSelect} name="levelTargetLanguage" value={languageData.levelTargetLanguage} onChange={handleLanguageDataChange}>
                                <option value="">Оберіть ваш рівень</option>
                                <option value="1">A1: Початковий</option>
                                <option value="2">A2: Базовий</option>
                                <option value="3">B1: Середній</option>
                                <option value="4">B2: Вище-середнього</option>
                                <option value="5">C1: Просунутий</option>
                                <option value="6">C2: Досвідчений</option>
                            </select>
                            <div className={styles.formButton}>
                                <Button click={handleValidateStep2}>Зареєструватись</Button>
                            </div>
                        </form>
                    </div>
                )}
                {error && (
                    <div className={styles.formError}>
                        {error}
                    </div>
                )}
                <div className={styles.swapAuthLink}>
                    <Link to="/login">Вже маєте аккаунт? Увійти.</Link>
                </div>
                <div className={styles.exterlaAuthorization}><GoogleAuthenticatedButton /></div>
            </div>
        </>
    );
}

export default RegisterPage;
