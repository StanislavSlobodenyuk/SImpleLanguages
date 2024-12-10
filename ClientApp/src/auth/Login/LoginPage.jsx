import { useState } from 'react';
import { sendLoginData } from '/src/api/AuthenticationApi/authenticationApi.js';
import { useNavigate, Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import checkAuthentication from '../checkAuthentication.jsx';
import styles from './login.module.less'


export default function LoginPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        userNameOrEmail: "",
        password: '',
        isRemember: '',
    })

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prev) => ({ ...prev, [name]: value }))
    }

    const sendData = async () => {
        console.log("a")
        var responseData = {}
        try {
            const response = await sendLoginData(formData);
            responseData = { success: true, message: "Реєстрація успішна!" };
        } catch (error) {
            responseData = { success: false, message: "Помилка при реєстрації!" };
        }

        checkAuthentication(responseData, dispatch, navigate);
    };

    return (
        <div className={styles.login}>
            <div className={styles.loginContainer}>
                <div className={styles.headBar}>
                    <img src='/src/img/logo.svg' className={styles.formImg}></img>
                    <span className={styles.headTitle}>Simple Languages</span>
                </div>
                <form className={styles.form} action="" method="post">
                    <div className={styles.formBlock}>
                        <label className={styles.label} htmlFor="userNameOrEmail">Ім'я акаунтку або пошта</label>
                        <input
                            type="text"
                            id="userNameOrEmail"
                            name="userNameOrEmail"
                            value={formData.userNameOrEmail}
                            onChange={handleInputChange}
                            required
                        />
                    </div>
                    <div className={styles.formBlock}>
                        <label className={styles.label} htmlFor="password">Пароль</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={formData.password}
                            onChange={handleInputChange}
                            required
                        />
                    </div>
                </form>
                <div>
                    <Link to="/register">Не пам'ятаю дані входу</Link>
                </div>
                <div className={styles.buttons}>
                    <Link to="/register">Зареєструватись</Link>
                    <div className={styles.linkLogin} onClick={sendData}>Увійти</div>
                </div>
            </div>
        </div>
    );
}