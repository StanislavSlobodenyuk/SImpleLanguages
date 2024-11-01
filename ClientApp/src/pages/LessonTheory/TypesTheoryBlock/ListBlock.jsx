import styles from './../lessonTheory.module.less'

export default function Listblock({ block }) {
    const ListData = JSON.parse(block.content)
    return (
        <div>
            {block.title && <p className={styles.theory__blockTitle}>{block.title}</p>}
            <ul className={styles.theory__list}>
                {ListData.map((content, index) => (
                    <li key={index}>{content}</li>
                ))}
            </ul>
        </div>
    );
}