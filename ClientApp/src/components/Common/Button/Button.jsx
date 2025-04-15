import styles from './Button.module.less'
import { useTheme } from '../../../Hooks/ThemeContext'

export default function Button({ children, click, type = "" }) {
    const { theme } = useTheme();

    const handleClick = () => {
        if (typeof click === "function") {
            click();
        }
    };

    return (
        <button
            type={type}
            className={`${styles.button} ${theme === 'dark' ? styles.buttonDarkTheme : styles.buttonLightTheme}`}
            onClick={handleClick}
        >
            {children}
        </button>
    );
}