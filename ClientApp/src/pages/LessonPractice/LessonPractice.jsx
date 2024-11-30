import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react";
import { FetchQuestion } from "/src/api/CourseApi/CourseApi";
import { QuestionTypeMapping } from "/src/Mapping/Mappinig";
import { useTheme } from "/src/Hooks/ThemeContext";
import styles from './lessonPractice.module.less'
import SimpleQuestion from "./QuestionsType/SimpleQuestion";
import AudioQuestion from "./QuestionsType/AudioQuestions";
import TextQuestion from "./QuestionsType/TextQuestion";
import ImageQuestion from "./QuestionsType/ImageQuestion";
import Button from '/src/components/Common/Button/Button'

const TaskRender = ({ question }) => {
    switch (QuestionTypeMapping[question.qType]) {
        case 'SimpleQuestion':
            return <SimpleQuestion question={question} />
        case 'AudioQuestion':
            return <AudioQuestion question={question} />
        case 'TextQuestion':
            return <TextQuestion question={question} />
        case 'ImageQuestion':
            return <ImageQuestion question={question} />
    }
}

export default function LessonPractice() {
    const { courseTitle, moduleTitle, lessonId } = useParams()
    const [isQuestions, setIsQuestions] = useState([])
    const [error, setError] = useState(null)
    const { theme } = useTheme()

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await FetchQuestion({ lessonId })
                console.log(data)
                setIsQuestions(data);
            } catch (error) {
                setError('Failes to fetch questions')
            }
        }
        fetchData();
    }, [lessonId])

    if (error) {
        return <div>{error}</div>
    }

    return (
        <div className={` ${styles.practice}`}>
            <h4 className={`${styles.practice__title} ${theme === 'dark' ? styles.darkText : styles.lightText}`}> Урок {lessonId}</h4>
            <div className={styles.practice__questions}>
                {isQuestions.map((question) =>
                    <div key={question.uniqueId} className={`${styles.practice__questions} ${"block__container"}`}>
                        <TaskRender question={question} />
                    </div>
                )}
            </div>
            <div className={styles.practice__buttonResults}>
                <Link to={`/course/${encodeURIComponent(courseTitle)}/module/${encodeURIComponent(moduleTitle)}/lessonPractice/${lessonId}/result`} >
                    <Button>Переглянути результати</Button>
                </Link>
            </div>
        </div>
    );
}