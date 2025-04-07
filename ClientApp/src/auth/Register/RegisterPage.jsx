import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { registerThunk } from "../../Redux/authSlice.js";
import { useNavigate } from "react-router-dom";
import GoogleAuthenticatedButton from "../GoogleAuth/GoogleAuthenticatedButton";

function RegisterPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { isAuthenticated } = useSelector(state => state.auth);

    const [step, setStep] = useState(1);
    const [userData, setUserData] = useState({
        userName: '',
        email: '',
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
    }
    const handleLanguageDataChange = (e) => {
        setLanguageData({ ...languageData, [e.target.name]: e.target.value });
    }

    const handleValidateStep1 = () => {
        if (userData.password !== userData.confirmedPassword) {
            console.log("Паролі не збігаються")
            return;
        }
        if (!userData.password || !userData.email || !userData.userName) {
            console.log("Не всі поля заповнені")
            return
        }

        setStep(2);
    }
    const handleValidateStep2 = () => {
        if (!languageData.nativeLanguage || !languageData.targetLanguage || !languageData.levelTargetLanguage) {
            console.log("Не всі поля заповнені")
            return
        }

        const registerData = { ...userData, ...languageData }
        dispatch(registerThunk(registerData));
    }

    return (
        <>
            {step === 1 && (
                <div>
                    <h2>Крок 1</h2>
                    <input
                        type="text"
                        name="userName"
                        value={userData.userName}
                        onChange={handleUserDataChange}
                        placeholder="User name"
                    />
                    <input
                        type="email"
                        name="email"
                        value={userData.email}
                        onChange={handleUserDataChange}
                        placeholder="Email"
                    />
                    <input
                        type="password"
                        name="password"
                        value={userData.password}
                        onChange={handleUserDataChange}
                        placeholder="Password"
                    />
                    <input
                        type="password"
                        name="confirmedPassword"
                        value={userData.confirmedPassword}
                        onChange={handleUserDataChange}
                        placeholder="Confim password"
                    />
                    <button onClick={handleValidateStep1}>Далі</button>
                </div>
            )}

            {step === 2 && (
                <div>
                    <h2>Крок 2</h2>
                    <form>
                        <input
                            type="text"
                            name="nativeLanguage"
                            value={languageData.nativeLanguage}
                            onChange={handleLanguageDataChange}
                            placeholder="Ваш родной язык"
                        />
                        <input
                            type="text"
                            name="targetLanguage"
                            value={languageData.targetLanguage}
                            onChange={handleLanguageDataChange}
                            placeholder="Язык, который хотите изучать"
                        />
                        <input
                            type="text"
                            name="levelTargetLanguage"
                            value={languageData.levelTargetLanguage}
                            onChange={handleLanguageDataChange}
                            placeholder="Уровень"
                        />
                        <button onClick={handleValidateStep2}>Зареєструватись</button>
                    </form>
                    <button onClick={() => navigate('/login')}> Вже маєте аккаунт? Увійти.</button>
                </div>
            )}
            <GoogleAuthenticatedButton />
        </>
    )
}

export default RegisterPage;