import { QuestionAnswerMapping } from "/src/Mapping/Mappinig";
import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'
import WritingAnswer from '../Answers/WritingAnswer';

export default function SimpleQuestion({ question }) {
    return (
        <div className={`${styles.simpleQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.uniqueId}. {question.questionText}</div>
            <div className={styles.simpleQuestion__answerTypes}>
                {QuestionAnswerMapping[question.aType] === 'Radio' && <RadioAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'CheckBox' && <CheckboxAnswer answers={question.answerOptions} />}
                {QuestionAnswerMapping[question.aType] === 'Input' && <InputAnswer />}
                {QuestionAnswerMapping[question.aType] === 'Writing' && <WritingAnswer />}
            </div>
        </div>
    );
} 