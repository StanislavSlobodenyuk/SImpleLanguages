import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'

export default function AudioQuestion({ question }) {
    return (
        <div className={`${styles.audioQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.id}. {question.questionText}</div>
            <div className={styles.audioQuestion__question}>
                <div className={styles.audioQuestion__audioContainer}>
                    <audio controls className={styles.audioQuestion__audio}>
                        <source src={question.audioUrl} type="audio/mpeg" />
                        Your browser does not support the audio tag.
                    </audio>
                </div>
                <div className={styles.audioQuestion__answerTypes}>
                    {question.answerType === 'radio' && <RadioAnswer answers={question.answers} />}
                    {question.answerType === 'checkbox' && <CheckboxAnswer answers={question.answers} />}
                    {question.answerType === 'input' && <InputAnswer answers={question.answers} />}
                </div>
            </div>
        </div>
    );
}