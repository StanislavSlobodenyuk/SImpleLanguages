import { useState } from 'react';
import { useTheme } from '../../Hooks/ThemeContext';
import WordsMix from './WordsMix';
import MiniProfile from './MiniProfile'
import Button from '../Common/Button/Button';
import styles from './header.module.less';
import logo from '../../img/logo.svg';

export default function Header({ authenticated }) {
    const { theme, changeTheme } = useTheme();
    const [currentLanguage, setCurrentLanguage] = useState('Україна(ua)');
    const [isOpenDownlist, setIsOpenDownlist] = useState(false);

    const handeOpenDownList = () => {
        setIsOpenDownlist(!isOpenDownlist)
    }

    return (
        <header className={theme === 'dark' ? "darkTheme" : "lightTheme"}>
            <div className={styles.header__container}>
                <img className={styles.header__logo} src={logo} alt="Logo" />
                {authenticated
                    ? (
                        <MiniProfile />
                    )
                    : (<WordsMix />)
                }
                <div className={styles.header__buttons}>
                    {authenticated &&
                        <>
                            <div className={styles.header__notification} onClick={handeOpenDownList}>
                                <img src="/src/img/general/notifications.svg" alt="Notification" />
                            </div>
                            {isOpenDownlist &&
                                <div className={styles.header__notificationDownList}>
                                    <div><p>notification1</p></div>
                                    <div><p>notification2</p></div>
                                    <div><p>notification3</p></div>
                                    <div><p>notification4</p></div>
                                    <div><p>notification5</p></div>
                                </div>
                            }
                        </>
                    }
                    <button
                        className={`${styles.header__themeButton} ${theme === 'dark' ? styles.header__themeButton_night : styles.header__themeButton_day}`} onClick={changeTheme}
                    >
                    </button>
                    <div className={`${styles.header__localizationButton} ${theme === 'dark' ? styles.localizationButton_dark : styles.localizationButton_light}`}>
                        <Button>{currentLanguage}</Button>
                    </div>
                </div>
            </div>
        </header>
    );
}
