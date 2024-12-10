import styles from './answers.module.less';
export default function InputAnswer() {
    return (
        <div className={styles.inputButtons}>
            Answer:
            <label className={styles.inputLabel}>
                <input
                    type="text"
                    name="answers"
                />
            </label>
        </div>
    );
}