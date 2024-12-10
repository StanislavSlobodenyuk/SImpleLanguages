import styles from './../lessonTheory.module.less';

export default function Listblock({ block }) {
    const ListData = JSON.parse(block.content)
    return (
        <div>
            {block.title && <p className={styles.theoryBlockTitle}>{block.title}</p>}
            <ul className={styles.theoryList}>
                {ListData.map((content, index) => (
                    <li key={index}>{content}</li>
                ))}
            </ul>
        </div>
    );
}