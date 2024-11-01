import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'

export default function TextQuestion({ question }) {
    return (
        <div className={`${styles.textQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.id}. {question.questionText}</div>
            <div className={styles.textQuestion__text}>{question.text}</div>
            <div className={styles.textQuestion__answerTypes}>
                {question.answerType === 'radio' && <RadioAnswer answers={question.answers} />}
                {question.answerType === 'checkbox' && <CheckboxAnswer answers={question.answers} />}
                {question.answerType === 'input' && <InputAnswer answers={question.answers} />}
            </div>
        </div>
    );
}