import { useTheme } from '../../Hooks/ThemeContext'
import { menuLinks } from '../Common/Menu/menuData'
import Maintitle from '../Common/MainTitle/MainTitle'
import Menu from '../Common/Menu/Menu'
import styles from './footer.module.less'
import logo from '../../img/logo.svg'

export default function Footer() {
    const { theme } = useTheme();

    return (
        <footer className={theme === 'dark' ? "dark-theme" : "light-theme"}>
            <div className={styles.footerContainer} >
                <div className={styles.footerLogoContainer}>
                    <img src={logo} alt="Logo" className={styles.footerLogo} />
                </div>
                <Maintitle location="footer" />
                <div className={styles.footerMenuContainer}>
                    <ul className={`${styles.footerMenu} ${theme === 'dark' ? styles.footerMenuDark : styles.footerMenuLight}`}>
                        {menuLinks.map((link, index) => (
                            <Menu key={index} {...link} />
                        ))}
                    </ul>
                </div>
                <div className={styles.footerPrivacyLinks}>
                    <a href="#">Privacy Polyci</a>
                    <a href="#">Privacy Notice</a>
                </div>
            </div>
        </footer>
    )
}