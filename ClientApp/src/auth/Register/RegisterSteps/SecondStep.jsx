import { useState } from "react";
import styles from "./styles.module.less"
export default function SecondStep({ formData, onChange, onNext, onPrev }) {
    const [errors, setErrors] = useState({});
    const handleInputChange = (e) => {
        const { name, value } = e.target
        onChange(name, value)
    }

    const validate = () => {
        const newErrors = {};

        if (formData.nativeLanguage === "") {
            newErrors.nativeLanguage = "Вкажіть вашу мову";
        }
        if (formData.learningLanguage === "") {
            newErrors.learningLanguage = "Виберіть мову дня навчання";
        }
        if (formData.learningLevel === "") {
            newErrors.learningLevel = "Вкажіть ваш рівень володіння мовою";
        }

        setErrors(newErrors);
        if (Object.keys(newErrors).length === 0) {
            onNext();
        }
    }

    return (
        <div className={styles.registerContainer}>
            <h2 className={styles.formTitle}>Крок 2: Мовні налаштування.</h2>
            <form className={styles.form} action="" method="post">
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="nativeLanguage">На якій мові ви розмовляєте?</label>
                    <select className={styles.input}
                        name="nativeLanguage"
                        value={formData.nativeLanguage}
                        onChange={handleInputChange}
                    >
                        <option value="">Рідна мова</option>
                        <option value="Ukraine">Українська</option>
                        <option value="English">English</option>
                        <option value="Polish">Polish</option>
                    </select>
                    {errors.nativeLanguage && <div className={styles.errorMessage}>{errors.nativeLanguage}</div>}
                </div>
                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="learningLanguage">Яку мову хотіли б вивчати?</label>
                    <select className={styles.input}
                        name="learningLanguage"
                        value={formData.learningLanguage}
                        onChange={handleInputChange}
                    >
                        <option value="">Мова яку бажаєте вивчити</option>
                        <option value="Ukraine">Українська</option>
                        <option value="English">English</option>
                    </select>
                    {errors.learningLanguage && <div className={styles.errorMessage}>{errors.learningLanguage}</div>}
                </div>

                <div className={styles.formBlock}>
                    <label className={styles.label} htmlFor="learningLevel">Ваш поточний рівень знань</label>
                    <select className={styles.input}
                        name="learningLevel"
                        value={formData.learningLevel}
                        onChange={handleInputChange}
                    >
                        <option value="">Рівень</option>
                        <option value="Ukraine">А1: Elementary</option>
                        <option value="English">A2: Pre-Intermediate</option>
                        <option value="Polish">B1: Intermediate </option>
                        <option value="Ukraine">B2: Upper-Intermediate</option>
                        <option value="English">C1: Advanced</option>
                        <option value="Polish">C2: Proficient</option>
                    </select>
                    {errors.learningLevel && <div className={styles.errorMessage}>{errors.learningLevel}</div>}
                </div>
            </form>
            <div className={styles.buttons}>
                <div className={styles.formButton} onClick={onPrev}>Повернутись</div>
                <div className={styles.formButton} onClick={validate}>Далі</div>
            </div>

        </div>
    )
}
