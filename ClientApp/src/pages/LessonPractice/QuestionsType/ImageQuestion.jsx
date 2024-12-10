import { QuestionAnswerMapping } from "/src/Mapping/Mappinig";
import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import WritingAnswer from "../Answers/WritingAnswer";
import styles from './qustions.module.less'

export default function ImageQuestion({ question }) {
    const images = question.images
    return (
        <div className={`${styles.imageQuestion} ${styles.question}`}>
            <div className={styles.questionTitle}>{question.uniqueId}. {question.questionText}</div>
            <img src={question.imagePath} className={styles.imageQuestionImage}></img>
            <div className={styles.imageQuestionAnswerTypes}>
                {QuestionAnswerMapping[question.aType] === 'Radio' && <RadioAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'CheckBox' && <CheckboxAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'Input' && <InputAnswer />}
                {QuestionAnswerMapping[question.aType] === 'Writing' && <WritingAnswer />}
            </div>
        </div>
    );
}