import { useState } from 'react';
import { useTheme } from '/src/Hooks/ThemeContext'
import styles from './searchBar.module.less'

export default function SearcBar({ id }) {
    const [currentSearch, setCurrentSearch] = useState("")
    const [hasError, setHasError] = useState(true)
    const { theme } = useTheme()

    const changeSearch = (event) => {
        const value = event.target.value;
        setCurrentSearch(value);

        setHasError(value.length === 0)
    }

    const checkError = (event) => {
        event.preventDefault();

        if (currentSearch.length === 0) {
            console.log('error')
        }
        else {
            // TODO: доробити відправку на сервер 
            console.log('Поиск:', currentSearch);
        }
    }

    return (
        <div className={styles.searcBar}>
            <form action="" className={styles.searcBar__form}>
                <input type="text" id={id} value={currentSearch} onChange={changeSearch} className={styles.searcBar__request} />

                <button className={styles.searcBar__button} onClick={checkError}>
                    {hasError ? (
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