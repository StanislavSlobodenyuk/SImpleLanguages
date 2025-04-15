import { useState } from 'react';
import { useTheme } from '../../Hooks/ThemeContext';
import { logoutThunk } from '../../Redux/authSlice';
import { useDispatch } from "react-redux";
import WordsMix from './WordsMix';
import MiniProfile from './MiniProfile';
import Button from '../Common/Button/Button';
import styles from './header.module.less';

export default function Header({ authenticated }) {
    const { theme, changeTheme } = useTheme();
    const [currentLanguage, setCurrentLanguage] = useState('Україна(ua)');
    const [isOpenDownlist, setIsOpenDownlist] = useState(false);
    const dispatch = useDispatch();

    const handeOpenDownList = () => {
        setIsOpenDownlist(!isOpenDownlist);
    };

    const handleLogoutClick = () => {
        dispatch(logoutThunk());
    };

    return (
        <header className={theme === 'dark' ? "dark-theme" : "light-theme"}>
            <div className={styles.headerContainer}>
                {authenticated
                    ? (
                        <MiniProfile />
                    )
                    : (<WordsMix />)
                }
                <div className={styles.headerButtons}>
                    {authenticated &&
                        <>
                            <div className={styles.headerNotification} onClick={handeOpenDownList}>
                                <img src="/src/img/general/notifications.svg" alt="Notification" />
                            </div>
                            {isOpenDownlist &&
                                <div className={styles.headerNotificationDownList}>
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
                        className={`${styles.headerThemeButton} ${theme === 'dark' ? styles.headerThemeButtonNight : styles.headerThemeButtonDay}`}
                        onClick={changeTheme}
                    >
                    </button>
                    <div className={`${styles.headerLocalizationButton} ${theme === 'dark' ? styles.localizationButtonDark : styles.localizationButtonLight}`}>
                        <Button>{currentLanguage}</Button>
                    </div>
                    {authenticated && (
                        <div className={`${styles.headerLogoutButton} ${theme === 'dark' ? styles.headerLogoutButtonNight : styles.headerLogoutButtonnDay}`}>
                            <Button click={handleLogoutClick} type="button">
                                Вийти
                            </Button>
                        </div>
                    )}
                </div>
            </div>
        </header>
    );
}
