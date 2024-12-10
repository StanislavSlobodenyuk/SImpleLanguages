import styles from './../lessonTheory.module.less';
import { useTheme } from '/src/Hooks/ThemeContext';

export default function Tableblock({ block }) {
    const { theme } = useTheme()
    const TableData = JSON.parse(block.content)
    return (
        <div>
            {block.title && <p className={styles.theoryBlockTitle}>{block.title}</p>}
            <table className={`${styles.theoryTable} ${theme === 'dark' ? styles.theoryTableDark : styles.theoryTableLight}`}>
                <tbody>
                    {TableData.map((row, index) => (
                        <tr className={styles.theoryTableRow} key={index}>
                            <td className={styles.theoryTableCoulumn}>{row.term}</td>
                            <td className={styles.theoryTableCoulumn}>{row.usage}</td>
                            <td className={styles.theoryTableCoulumn}>{row.example}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}