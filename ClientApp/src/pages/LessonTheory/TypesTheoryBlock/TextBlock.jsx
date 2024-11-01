import styles from './../lessonTheory.module.less'

export default function Textblock({ block }) {
    return (
        <div>
            {block.title && <p className={styles.theory__blockTitle}>{block.title}</p>}
            <div className={styles.theory__textContent}>{block.content}</div>
        </div>
    );
}