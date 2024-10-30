import styles from './Button.module.less'
import { useTheme } from '../../../Hooks/ThemeContext'

export default function Button({ children, click }) {
    const { theme } = useTheme();

    const handleClick = () => {
        if (typeof click === "function") {
            click();
        }
    };

    return (
        <button className={`${styles.button} ${theme === 'dark' ? styles.button_darkTheme : styles.button_lightTheme} `} onClick={handleClick}>{children}</button>
    )
}