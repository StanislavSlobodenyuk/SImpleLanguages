import { useEffect, useState } from 'react';
import Button from '/src/components/Common/Button/Button';
import styles from './lessonLink.module.less';
import { useTheme } from '/src/Hooks/ThemeContext';


export default function LessonLink({ lesson, currentLesson, onLessonSelect, style, openModal }) {
    const [isAnimating, setIsAnimating] = useState(false);
    const [shouldRender, setShouldRender] = useState(false);
    const { theme } = useTheme()

    useEffect(() => {
        if (lesson.id === currentLesson.id) {
            setShouldRender(true);
            setIsAnimating(false);
        } else if (shouldRender) {
            setIsAnimating(true);
            const timer = setTimeout(() => {
                setShouldRender(false);
            }, 2000);
            return () => clearTimeout(timer);
        }
    }, [currentLesson, lesson.id]);

    const handleSelectLesson = () => {
        onLessonSelect(lesson);
    };

    return (
        <div style={style} className={styles.lessonLink}>
            <div className={`
                ${styles.lessonLink__figure} 
                ${lesson.isComplete ? (theme === 'dark' ? styles.lessonLink__figure_dark : styles.lessonLink__figure_light) : ''}
            `} onClick={handleSelectLesson}>
                <div className={styles.lessonLink__number}>L {lesson.id}</div>
            </div>
            {shouldRender && (
                <div className={`
                    ${styles.lessonLink__animation} 
                    ${isAnimating ? styles.flyIn : styles.flyOut}
                    ${theme === 'dark' ? styles.lessonLink__animation_dark : styles.lessonLink__animation_light}
                `}>
                    <div className={styles.lessonLink__text}>{lesson.title}</div>
                    <Button click={openModal}>Почати</Button>
                </div>
            )}
        </div>
    );
}