import styles from './maitTitle.module.less'
import { useTheme } from '../../../Hooks/ThemeContext';

export default function Maintitle({ location }) {
    const { theme } = useTheme();
    const className = location === 'footer' ? `${styles.footer__title}` : `${styles.sidebar__title}`;

    return (
        <div className={`${className} ${theme === 'dark' ? styles.title_dark : styles.title_light}`}>
            <div> Simple Languages </div>
            <div>School</div>
        </div>
    )
}