import RadioAnswer from '../Answers/RadioAnswer';
import CheckboxAnswer from '../Answers/CheckboxAnswer'
import InputAnswer from '../Answers/InputAnswer'
import styles from './qustions.module.less'

export default function ImageQuestion({ question }) {
    const images = question.images
    return (
        <div className={`${styles.imageQuestion} ${styles.question}`}>
            <div className={styles.question__title}>{question.id}. {question.questionText}</div>
            <div className={styles.imageQuestion__image}>
                {images.map((image, index) => (
                    <img key={index} src={image}></img>
                ))}
            </div>
            <div className={styles.imageQuestion__answerTypes}>
                {question.answerType === 'radio' && <RadioAnswer answers={question.answers} />}
                {question.answerType === 'checkbox' && <CheckboxAnswer answers={question.answers} />}
                {question.answerType === 'input' && <InputAnswer />}
            </div>
        </div>
    );
}