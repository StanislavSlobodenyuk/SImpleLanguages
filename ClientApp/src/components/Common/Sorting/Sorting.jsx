import { useTheme } from '/src/Hooks/ThemeContext';
import { useState } from 'react';
import styles from './sorting.module.less';

export default function Sorting() {
    const [currentSorting, setSorting] = useState("Порядок сортування");
    const [isOpen, setIsOpen] = useState(false);
    const { theme } = useTheme();

    const toggleDropdown = () => {
        setIsOpen(!isOpen);
    };

    const handleSortOptions = (option) => {
        setSorting(option);
        setIsOpen(false);

        // TODO: добавить передачу опции сортировки на сервер
    };

    return (
        <>
            <div className={styles.sorting} onClick={toggleDropdown}>
                <div className={styles.sortingImg}>
                    {theme === 'dark'
                        ? <img src='/src/img/general/sorting_dark.svg' alt='Sort' />
                        : <img src='/src/img/general/sorting_light.svg' alt='Sort' />}
                </div>
                <div className={styles.sortingText}>Порядок сортування</div>
            </div>
            {isOpen && (
                <div className={`${styles.dropdown} ${theme === 'dark' ? styles.dropdownDark : styles.dropdownLight}`}>
                    <div className={styles.dropdownOptions}>
                        <div key="popular" onClick={() => handleSortOptions("popular")}>
                            За популярністю
                        </div>
                        <div key="date" onClick={() => handleSortOptions("date")}>
                            За датою
                        </div>
                    </div>
                </div>
            )}
        </>
    );
}