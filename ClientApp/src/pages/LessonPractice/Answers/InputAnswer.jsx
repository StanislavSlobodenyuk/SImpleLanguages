import styles from './answers.module.less'
export default function InputAnswer() {
    return (
        <div className={styles.input__buttons}>
            Answer:
            <label className={styles.input__label}> 
                <input
                    type="text"
                    name="answers"
                />
            </label>
        </div>
    );
}