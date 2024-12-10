import { Link } from 'react-router-dom';
import { useTheme } from '/src/Hooks/ThemeContext';
import { languageMapping, levelMapping } from '/src/Mapping/Mappinig';
import Button from '/src/components/Common/Button/Button';
import styles from './courseCard.module.less';

export default function CourseCard({ course }) {
    const { theme } = useTheme()
    const scrollToTop = () => {
        const scrollStep = -window.scrollY / 15;
        const scrollInterval = setInterval(() => {
            if (window.scrollY !== 0) {
                window.scrollBy(0, scrollStep);
            } else {
                clearInterval(scrollInterval);
            }
        }, 15);
    }
    return (
        <div key={course.id} className={styles.course}>
            <div className={styles.image}>
                <Link to={`/course/${course.id}`} onClick={scrollToTop}>
                    <img src={course.imgPath} alt="1" />
                </Link>
            </div>
            <div className={`${styles.content} ${theme === 'dark' ? styles.contentDark : styles.contentLight}`}>
                <div className={styles.title}>{course.title}</div>
                <div className={styles.level}>Рівень: {levelMapping[course.level]}</div>
                <div className={styles.language}>Мова: {languageMapping[course.language]}</div>
                <div className={styles.description}> {course.description}</div>
                <div className={styles.buttonFlexContainer}>
                    <Link to={`/course/${course.id}`} onClick={scrollToTop}>
                        <Button>Переглянути</Button>
                    </Link>
                    <Link to={`/course/${course.id}/lessons`} onClick={scrollToTop}>
                        <Button>Розпочати</Button>
                    </Link>
                </div>
            </div>
        </div>
    );
}