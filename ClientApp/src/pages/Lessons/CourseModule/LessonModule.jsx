import { useState } from 'react';
import { useTheme } from '/src/Hooks/ThemeContext';
import styles from './lessonModule.module.less';

export default function LessonModule({ module, onModuleSelect, currentModuleId }) {
    const [isOpen, setIsOpen] = useState(true);
    const { theme } = useTheme()

    const toggleDropdown = () => {
        setIsOpen((prev) => !prev);
    };

    return (
        <div className={styles.lessons}>
            <div
                className={`
                ${styles.lessons__flex} 
                ${module.id === currentModuleId ? styles.lessons__flex_active : ''} 
                ${theme === 'dark' ? styles.lessons__flex_dark : styles.lessons__flex_light}`}
            >
                <div className={styles.lessons__text} onClick={onModuleSelect}>
                    <b>Модуль {module.id}.</b> {module.title}
                </div>
                <div className={`${styles.lessons__dropdownList} ${isOpen ? styles.lessons__dropdownList_open : ''}`} onClick={toggleDropdown} />
            </div>
            {isOpen && module.lessons.map((lesson) => (
                <div className={styles.lesson} key={lesson.id}>
                    <div className={styles.lesson__content}>
                        <div className={styles.lesson__title}>{lesson.title}</div>
                        <div className={styles.lesson__countTask}>12 завдань</div>
                    </div>
                </div>
            ))}
        </div>
    );
}
