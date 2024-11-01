import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'
import WritingAnswer from '../Answers/WritingAnswer';

export default function SimpleQuestion({ question }) {
    return (
        <div className={`${styles.simpleQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.id}. {question.questionText}</div>
            <div className={styles.simpleQuestion__answerTypes}>
                {question.answerType === 'radio' && <RadioAnswer answers={question.answers} />}
                {question.answerType === 'checkbox' && <CheckboxAnswer answers={question.answers} />}
                {question.answerType === 'input' && <InputAnswer />}
                {question.answerType === 'writing' && <WritingAnswer />}

            </div>
        </div>
    );
}