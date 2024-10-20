import WordsMix from './WordsMix';
import Button from '../Common/Button/Button';
import { useState } from 'react';
import { useTheme } from '../Hooks/ThemeContext';
import styles from './header.module.less';
import logo from '../../img/logo.svg';

export default function Header() {
    const { theme, changeTheme } = useTheme();
    const [currentLanguage, setCurrentLanguage] = useState('Україна(ua)');

    return (
        <header className={theme === 'dark' ? "darkTheme" : "lightTheme"}>
            <div className={styles.header__container}>
                <img className={styles.header__logo} src={logo} alt="Logo" />
                <WordsMix />
                <div className={styles.header__buttons}>
                    <button
                        className={`${styles.header__themeButton} ${theme === 'dark' ? styles.header__themeButton_night : styles.header__themeButton_day}`} onClick={changeTheme}
                    >
                    </button>
                    <div className={`${styles.header__localizationButton} ${theme === 'dark' ? styles.localizationButton_dark : styles.localizationButton_light}`}>
                        <Button>{currentLanguage}</Button>
                    </div>
                    <Button>Увійти</Button>
                </div>
            </div>
        </header>
    );
}
