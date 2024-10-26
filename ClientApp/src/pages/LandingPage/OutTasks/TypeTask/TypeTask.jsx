import styles from "./typeTask.module.less"

export default function TypeTask({ src, title, description, amount }) {
    return (
        <div className={styles.item}>
            <div className={styles.content}>
                <h4 className={styles.title}>{title}</h4>
                <p className={styles.text}>{description}</p>
                <p className={styles.secondText}>Загальна кількість: {amount}</p>
            </div>
            <div className={styles.image}>
                <img src={src} alt="Content" />
            </div>
        </div>
    )
}