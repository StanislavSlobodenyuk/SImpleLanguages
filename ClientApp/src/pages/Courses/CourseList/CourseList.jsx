import { useTheme } from '/src/Hooks/ThemeContext'
import Button from '/src/components/Common/Button/Button'
import styles from './courseList.module.less'

export default function CourseList({ courses }) {
    const { theme } = useTheme()
    return (
        <div className={styles.courses}>
            {courses.length > 0
                ? (
                    courses.map(course => (
                        <div key={course.id} className={styles.course}>
                            <div className={styles.image}>
                                <img src={course.image} alt="" />
                            </div>
                            <div className={`${styles.content} ${theme === 'dark' ? styles.content_dark : styles.content_light}`}>
                                <div className={styles.title}>{course.title}</div>
                                <div className={styles.flexContainer}>
                                    <div className={styles.level}>Рівень: {course.level}</div>
                                    <div className={styles.language}>Мова: {course.language}</div>
                                </div>
                                <div className={styles.description}> {course.description}</div>
                                <div className={styles.buttonFlexContainer}>
                                    <Button>Переглянути</Button>
                                    <Button>Розпочати</Button>
                                </div>
                            </div>
                        </div>
                    ))
                )
                : (<div>Курси не знайдено</div>)
            }
        </div>
    );
}