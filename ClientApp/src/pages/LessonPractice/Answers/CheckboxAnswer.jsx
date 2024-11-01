import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less'

export default function CheckboxAnswer({ answers }) {
    const { theme } = useTheme()
    return (
        <div className={`${styles.checkBox__buttons} ${theme === 'dark' ? styles.checkBox__buttons_dark : styles.checkBox__buttons_light}`}>
            {answers.map((answer, index) => (
                <label key={index} className={styles.checkBox__label}>
                    <input
                        type="checkBox"
                        name="answers"
                        value={answer}
                    />
                    {answer}
                </label>
            ))}
        </div>
    );
}