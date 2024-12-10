import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less';

export default function RadioAnswer({ answers }) {
    const { theme } = useTheme();
    return (
        <div className={`${styles.radioButtons} ${theme === 'dark' ? styles.radioButtonsDark : styles.radioButtonsLight}`}>
            {answers.map((answer) => (
                <label key={answer.id} className={styles.radioLabel}>
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
