import styles from './Button.module.less'
import { useTheme } from '../../Hooks/ThemeContext'

export default function Button({ children }) {
    const { theme } = useTheme();
    return (
        <button className={`${styles.button} ${theme === 'dark' ? styles.button_darkTheme : styles.button_lightTheme} `}>{children}</button>
    )
}