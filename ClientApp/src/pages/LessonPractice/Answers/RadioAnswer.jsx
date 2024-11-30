import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less'

export default function RadioAnswer({ answers }) {
    const { theme } = useTheme();
    return (
        <div className={`${styles.radio__buttons} ${theme === 'dark' ? styles.radio__buttons_dark : styles.radio__buttons_light}`}>
            {answers.map((answer) => (
                <label key={answer.id} className={styles.radio__label}>
                    <input
                        type="radio"
                        name="answers"
                        value={answer.option}
                    />
                    {answer.option}
                </label>
            ))}
        </div>
    );
}
