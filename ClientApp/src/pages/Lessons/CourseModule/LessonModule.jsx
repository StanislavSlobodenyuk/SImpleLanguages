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
                ${styles.lessonsFlex} 
                ${module.id === currentModuleId ? styles.lessonsFlexActive : ''} 
                ${theme === 'dark' ? styles.lessonsDark : styles.lessonsLight}`}
            >
                <div className={styles.lessonsText} onClick={onModuleSelect}>
                    <b>Модуль {module.id}.</b> {module.title}
                </div>
                <div className={`${styles.lessonsDropdownList} ${isOpen ? styles.lessonsDropdownListOpen : ''}`} onClick={toggleDropdown} />
            </div>
            {isOpen && module.lessons.map((lesson) => (
                <div className={styles.lesson} key={lesson.id}>
                    <div className={styles.lessonContent}>
                        <div className={styles.lessonTitle}>{lesson.title}</div>
                        <div className={styles.lessonCountTask}>12 завдань</div>
                    </div>
                </div>
            ))}
        </div>
    );
}
