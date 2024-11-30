import { QuestionAnswerMapping } from "/src/Mapping/Mappinig.js";
import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'
import WritingAnswer from "../Answers/WritingAnswer";

export default function AudioQuestion({ question }) {
    return (
        <div className={`${styles.audioQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.uniqueId}. {question.questionText}</div>
            <div className={styles.audioQuestion__question}>
                <div className={styles.audioQuestion__audioContainer}>
                    <audio controls className={styles.audioQuestion__audio}>
                        <source src={question.audioUrl} type="audio/mpeg" />
                        Your browser does not support the audio tag.
                    </audio>
                </div>
                <div className={styles.audioQuestion__answerTypes}>
                    {QuestionAnswerMapping[question.aType] === 'Radio' && <RadioAnswer answers={question.answerOptions} />}
                    {QuestionAnswerMapping[question.aType] === 'CheckBox' && <CheckboxAnswer answers={question.answerOptions} />}
                    {QuestionAnswerMapping[question.aType] === 'Input' && <InputAnswer />}
                    {QuestionAnswerMapping[question.aType] === 'Writing' && <WritingAnswer />}
                </div>
            </div>
        </div>
    );
}