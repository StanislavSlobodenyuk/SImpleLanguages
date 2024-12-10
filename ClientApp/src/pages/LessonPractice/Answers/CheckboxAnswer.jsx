import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './answers.module.less';

export default function CheckboxAnswer({ answers }) {
    const { theme } = useTheme()
    return (
        <div className={`${styles.checkBoxButtons} ${theme === 'dark' ? styles.checkBoxButtonsDark : styles.checkBoxButtonsLight}`}>
            {answers.map((answer) => (
                <label key={answer.id} className={styles.checkBoxLabel}>
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