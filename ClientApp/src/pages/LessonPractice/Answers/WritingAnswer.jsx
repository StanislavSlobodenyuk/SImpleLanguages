import styles from './answers.module.less'

export default function WritingAnswer() {
    return (
        <div className={styles.writing__buttons}>
            <textarea
                name="answers"
                rows="8"
                cols="120"
                placeholder="Enter your answer here..."
                className={styles.writing__textarea}
            />
        </div>
    );
}