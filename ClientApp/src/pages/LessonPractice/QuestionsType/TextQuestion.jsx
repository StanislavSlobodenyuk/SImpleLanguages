import { QuestionAnswerMapping } from "/src/Mapping/Mappinig.js"
import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import WritingAnswer from '../Answers/WritingAnswer';
import styles from './qustions.module.less'

export default function TextQuestion({ question }) {
    return (
        <div className={`${styles.textQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.uniqueId}. {question.questionText}</div>
            <div className={styles.textQuestion__text}>{question.text}</div>
            <div className={styles.textQuestion__answerTypes}>
                {QuestionAnswerMapping[question.aType] === 'Radio' && <RadioAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'CheckBox' && <CheckboxAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'Input' && <InputAnswer />}
                {QuestionAnswerMapping[question.aType] === 'Writing' && <WritingAnswer />}
            </div>
        </div>
    );
}