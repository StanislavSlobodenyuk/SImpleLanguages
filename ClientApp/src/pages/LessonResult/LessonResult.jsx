import { Link, useParams } from "react-router-dom";
import Button from '/src/components/Common/Button/Button';
import styles from './lessonResult.module.less';

const result = {
    countAnswers: 5,
    countRightAnswers: 5,
}

export default function LessonResult() {
    const { courseTitle, moduleTitle, lessonId } = useParams()
    return (
        <div className={`${"block-container"} ${styles.result}`}>
            <h4  >Курс "{courseTitle}" модуль "{moduleTitle}" урок {lessonId}</h4>
            <div className={styles.resultText}>
                <div>Всього відповідей: {result.countAnswers}</div>
                <div>Кількість правильних відповідей: {result.countRightAnswers}</div>
            </div>
            <div className={styles.resultButtons}>
                <Button>Подивитися результати</Button>
                <Link to={`/course/${encodeURIComponent(courseTitle)}/module/${encodeURIComponent(moduleTitle)}/lessonTheory/${lessonId}`}>
                    <Button>Перейти до лекції</Button>
                </Link>
                <Link to={`/course/${encodeURIComponent(courseTitle)}/module/${encodeURIComponent(moduleTitle)}/lessonPractice/${lessonId}`}>
                    <Button>Пройти тест знову</Button>
                </Link>
                <Link to={`/course/${courseTitle}/lessons`}>
                    <Button>Перейти до списку уроків</Button>
                </Link>
            </div>
        </div>
    );
}