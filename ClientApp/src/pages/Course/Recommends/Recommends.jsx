import { useState, useEffect } from 'react';
import { FetchCourses } from '/src/api/CourseApi/CourseApi.js';
import CourseCard from '../../../components/Common/CourseCard/CourseCard';
import styles from './recommends.module.less'
import { useTheme } from '/src/Hooks/ThemeContext';

export default function Recommends({ course }) {
    const [courses, setCourses] = useState([]);
    const [error, setError] = useState(null);
    const { theme, changeTheme } = useTheme();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await FetchCourses({
                    language: course.language,
                    level: course.level,
                })
                setCourses(data)
            } catch (error) {
                setError('Failed to fetch courses')
            }
        };

        fetchData()
    }, [course]);

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <div className={styles.recommends}>
            <h3 className={`${styles.recommendsTitle} ${theme === 'dark' ? 'dark-theme' : 'light-theme'}`}>Схожі курси</h3>
            <div className={styles.recommendsCourses}>
                {
                    courses.map((course) => (
                        <div key={course.id}>
                            <CourseCard course={course} />
                        </div>
                    ))
                }
            </div>
        </div>
    );
}