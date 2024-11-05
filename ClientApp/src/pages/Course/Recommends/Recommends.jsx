import { useState, useEffect } from 'react';
import { FetchCourses } from '/src/api/CourseApi/CourseApi.js';
import CourseCard from '../../../components/Common/CourseCard/CourseCard';
import styles from './recommends.module.less'

export default function Recommends({ course }) {
    const [courses, setCourses] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await FetchCourses({
                    language: course.language,
                    level: course.level,
                })
                console.log(data)
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
        <div className={`${'block__container'} ${styles.recommends}`}>
            <h3 className={styles.recommends__title}>Схожі курси</h3>
            <div className={styles.recommends__courses}>
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