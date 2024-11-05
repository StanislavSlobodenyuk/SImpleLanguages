import { useState } from 'react';
import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './searchBar.module.less';

export default function SearchBar({ id, onSearchChange }) {
    const [currentSearch, setCurrentSearch] = useState('');
    const { theme } = useTheme();

    const changeSearch = (event) => {
        const value = event.target.value;
        setCurrentSearch(value);
        onSearchChange(value);
    };

    return (
        <div className={styles.searcBar}>
            <form action="" className={styles.searcBar__form}>
                <input type="text" id={id} value={currentSearch} onChange={changeSearch} className={styles.searcBar__request} />

                <button className={styles.searcBar__button}>
                    {currentSearch.length === 0 ? (
                        <img src="/src/img/general/search_notActive.svg" alt="Error icon" />
                    ) : theme === 'dark' ? (
                        <img src="/src/img/general/search_dark.svg" alt="Search icon" />
                    ) : (
                        <img src="/src/img/general/search_light.svg" alt="Search icon" />
                    )}
                </button>
            </form>
        </div>
    );
}