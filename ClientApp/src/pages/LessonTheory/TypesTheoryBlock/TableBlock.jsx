import styles from './../lessonTheory.module.less'
import { useTheme } from '/src/Hooks/ThemeContext'

export default function Tableblock({ block }) {
    const { theme } = useTheme()
    const TableData = JSON.parse(block.content)
    return (
        <div>
            {block.title && <p className={styles.theory__blockTitle}>{block.title}</p>}
            <table className={`${styles.theory__table} ${theme === 'dark' ? styles.theory__table_dark : styles.theory__table_light}`}>
                <tbody>
                    {TableData.map((row, index) => (
                        <tr className={styles.theory__tableRow} key={index}>
                            <td className={styles.theory__tableCoulumn}>{row.term}</td>
                            <td className={styles.theory__tableCoulumn}>{row.usage}</td>
                            <td className={styles.theory__tableCoulumn}>{row.example}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}