import { QuestionAnswerMapping } from "/src/Mapping/Mappinig.js"
import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import WritingAnswer from '../Answers/WritingAnswer';
import styles from './qustions.module.less'

export default function TextQuestion({ question }) {
    return (
        <div className={`${styles.textQuestion} ${styles.question}`}>
            <div className={styles.questionTitle}>{question.uniqueId}. {question.questionText}</div>
            <div className={styles.textQuestionText}>{question.text}</div>
            <div className={styles.textQuestionAnswerTypes}>
                {QuestionAnswerMapping[question.aType] === 'Radio' && <RadioAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'CheckBox' && <CheckboxAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'Input' && <InputAnswer />}
                {QuestionAnswerMapping[question.aType] === 'Writing' && <WritingAnswer />}
            </div>
        </div>
    );
}