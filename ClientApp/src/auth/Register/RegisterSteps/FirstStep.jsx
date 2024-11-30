import { useState } from 'react';
import { Link } from 'react-router-dom'
import styles from './styles.module.less'

export default function FirstStep({ formData, onChange, onNext }) {
    const [errors, setErrors] = useState({});
    const handleInputChange = (e) => {
        const { name, value } = e.target
        onChange(name, value)
    }

    const validate = () => {
        const newErrors = {};

        if (!formData.userName || formData.userName.length < 3 || formData.userName.length > 30) {
            newErrors.userName = "Нікнейм має бути від 3 до 30 символів.";
        }

        if (!formData.email.match(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)) {
            newErrors.email = "Введіть коректну електронну пошту.";
        }

        if (!formData.password || formData.password.length <= 5) {
            newErrors.password = "Пароль має бути довшим за 5 символів.";
        }

        if (!formData.password || !formData.password.match(/^(?=.*[a-zA-Z])(?=.*\d)/)) {
            newErrors.password = "Пароль має містити латинські букви та цифри";
        }

        if (formData.password !== formData.confirmedPassword) {
            newErrors.confirmedPassword = "Паролі не співпадають.";
        }

        setErrors(newErrors);
        if (Object.keys(newErrors).length === 0) {
            onNext();
        }
    }

    return (
        <div className={styles.registerContainer}>
            <h2 className={styles.formTitle}>Крок 1: Основна інформація</h2>
            <form className={styles.form} action="" method="post">
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="userName">Придумайте нікнейм</label>
                    <input className={styles.input}
                        type="text"
                        id="userName"
                        name="userName"
                        value={formData.userName || ""}
                        onChange={handleInputChange}
                        required
                    />
                    {errors.userName && <div className={styles.errorMessage}>{errors.userName}</div>}
                </div>
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="email">Введіть пошту</label>
                    <input className={styles.input}
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleInputChange || ""}
                        autoComplete="off"
                        required
                    />
                    {errors.email && <div className={styles.errorMessage}>{errors.email}</div>}
                </div>
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="password">Пароль</label>
                    <input className={styles.input}
                        type="password"
                        id="password"
                        name='password'
                        value={formData.password || ""}
                        onChange={handleInputChange}
                        autoComplete="off"
                        required
                    />
                    {errors.password && <div className={styles.errorMessage}>{errors.password}</div>}
                </div>
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="confirmedPassword">Підтвердіть пароль</label>
                    <input className={styles.input}
                        type="password"
                        id="confirmedPassword"
                        name="confirmedPassword"
                        value={formData.confirmedPassword || ""}
                        onChange={handleInputChange}
                        autoComplete="off"
                        required
                    />
                    {errors.confirmedPassword && <div className={styles.errorMessage}>{errors.confirmedPassword}</div>}
                </div>
            </form>
            <div className={styles.buttons}>
                <Link to="/login">Я вже маю акаунт</Link>
                <div className={styles.formButton} onClick={validate}>Далі</div>
            </div>
        </div>
    )
}

