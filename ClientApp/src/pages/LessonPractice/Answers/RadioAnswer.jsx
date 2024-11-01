import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less'

export default function RadioAnswer({ answers }) {
    const { theme } = useTheme()
    return (
        <div className={`${styles.radio__buttons} ${theme === 'dark' ? styles.radio__buttons_dark : styles.radio__buttons_light}`}>
            {answers.map((answer, index) => (
                <label key={index} className={styles.radio__label}>
                    <input
                        type="radio"
                        name="answers"
                        value={answer}
                    />
                    {answer}
                </label>
            ))}
        </div>
    );
}