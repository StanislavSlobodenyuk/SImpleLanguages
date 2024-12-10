import styles from './../lessonTheory.module.less';

export default function Textblock({ block }) {
    return (
        <div>
            {block.title && <p className={styles.theoryBlockTitle}>{block.title}</p>}
            <div className={styles.theoryTextContent}>{block.content}</div>
        </div>
    );
}