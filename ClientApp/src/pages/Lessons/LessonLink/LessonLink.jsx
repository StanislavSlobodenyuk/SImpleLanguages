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
        <div style={style} className={`${styles.lessonLink} ${theme === 'dark' ? styles.lessonLinkDark : styles.lessonLinkLight}`}>
            <div className={`
                ${styles.lessonLinkFigure} 
                ${lesson.isComplete ? (theme === 'dark' ? styles.lessonLinkFigureDark : styles.lessonLinkFigureLight) : ''}
            `} onClick={handleSelectLesson}>
                <div className={styles.lessonLinkNumber}>L {lesson.id}</div>
            </div>
            {shouldRender && (
                <div className={`
                    ${styles.lessonLinkAnimation} 
                    ${isAnimating ? styles.flyIn : styles.flyOut}
                    ${theme === 'dark' ? styles.lessonLinkAnimationDark : styles.lessonLinkAnimationLight}
                `}>
                    <div className={styles.lessonLinkText}>{lesson.title}</div>
                    <Button click={openModal}>Почати</Button>
                </div>
            )}
        </div>
    );
}