import styles from './maitTitle.module.less';
import { useTheme } from '../../../Hooks/ThemeContext';

export default function Maintitle({ location }) {
    const { theme } = useTheme();
    const className = location === 'footer' ? `${styles.footerTitle}` : `${styles.sidebarTitle}`;

    return (
        <div className={` ${className} ${theme === 'dark' ? styles.titleDark : styles.titleLight}`}>
            <div> Simple Languages </div>
            <div>School</div>
        </div>
    )
}