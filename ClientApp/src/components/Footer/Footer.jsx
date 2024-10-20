import { useTheme } from '../Hooks/ThemeContext'
import { menuLinks } from '../Common/Menu/menuData'
import Maintitle from '../Common/MainTitle/MainTitle'
import Menu from '../Common/Menu/Menu'
import styles from './footer.module.less'
import logo from '../../img/logo.svg'

export default function Footer() {
    const { theme } = useTheme();

    return (
        <footer className={theme === 'dark' ? "darkTheme" : "lightTheme"}>
            <div className={styles.footer__container} >
                <div className={styles.footer__logoContainer}>
                    <img src={logo} alt="Logo" className={styles.footer__logo} />
                </div>
                <Maintitle location="footer" />
                <div className={styles.footer__menuContainer}>
                    <ul className={`${styles.footer__menu} ${theme === 'dark' ? styles.footer__menu_dark : styles.footer__menu_light}`}>
                        {menuLinks.map((link, index) => (
                            <Menu key={index} {...link} />
                        ))}
                    </ul>
                </div>
                <div className={styles.footer__privacy_links}>
                    <a href="#">Privacy Polyci</a>
                    <a href="#">Privacy Notice</a>
                </div>
            </div>
        </footer>
    )
}