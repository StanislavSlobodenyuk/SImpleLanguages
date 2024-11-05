import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { FetchCourse } from '../../api/CourseApi/CourseApi';
import DescriptionBlock from './DescriptionBlock/DescriptionBlock';
import Comments from './Comments/Comments';
import Recommends from './Recommends/Recommends';

export default function Course() {
    const { id } = useParams();
    const [course, setIsCourse] = useState({})
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            try {

                const data = await FetchCourse({
                    courseId: id
                })
                console.log(data)
                setIsCourse(data)
            } catch (error) {
                setError('Failed to fetch course')
            }
        }
        fetchData();
    }, [id])

    if (error) {
        return <div>{error}</div>;
    }

    return (
        <>
            <section><DescriptionBlock course={course} /></section>
            <div style={{ display: 'flex', gap: '20px' }}>
                <section><Comments /></section>
                <section><Recommends course={course} /></section>
            </div>
        </>
    );
}