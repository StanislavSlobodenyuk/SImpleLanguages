import styles from './answers.module.less'

export default function WritingAnswer() {
    return (
        <div className={styles.writingButtons}>
            <textarea
                name="answers"
                rows="1"
                cols="50"
                placeholder="Enter your answer here..."
                className={styles.writingTextarea}
            />
        </div>
    );
}