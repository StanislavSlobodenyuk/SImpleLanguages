import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less'

export default function CheckboxAnswer({ answers }) {
    const { theme } = useTheme()
    return (
        <div className={`${styles.checkBox__buttons} ${theme === 'dark' ? styles.checkBox__buttons_dark : styles.checkBox__buttons_light}`}>
            {answers.map((answer) => (
                <label key={answer.id} className={styles.checkBox__label}>
                    <input
                        type="checkbox"
                        name="answers"
                        value={answer.option}
                    />
                    {answer.option}
                </label>
            ))}
        </div>
    );
}