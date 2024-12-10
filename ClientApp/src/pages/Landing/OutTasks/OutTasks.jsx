import TypeTask from './TypeTask/TypeTask.jsx'
import { dataType } from './typeTasks.js'
import { useTheme } from '../../../Hooks/ThemeContext.jsx'
import styles from './outTasks.module.less'

export default function OutTasks() {
    const { theme } = useTheme()
    return (
        <div className={`${"block-container"} ${styles.outTasks}`}>
            <h2 className={styles.outTasksTitle}>Різні типи завдань</h2>
            <p className={styles.outTasksText}>Після вибору курсу, ви можете розпочати ваше навчення по різному:</p>
            <div className={`${styles.outTasksTypesTasks} ${theme === 'dark' ? styles.outTasksTypesTasksDark : styles.outTasksTypesTaskLight} `}>
                <TypeTask {...dataType[0]} />
                <TypeTask {...dataType[1]} />
                <TypeTask {...dataType[2]} />
            </div>
            <p className={styles.outTasksText}>Важливий момент! В кожному курсі  щоб відкрити більш тяжкі завдання, для початку вам потрібно виконати попердні завдання. Данна фіча(функція) була задумана, для того щоб ви могли пройти кожен урок, та закріпити увесь матеріал. Якщо ж ви вже знаете матеріал уроку, то ви можете його пропустити за внутріньо проекту валюту, або ж  пропустити теорію та пройти практичну частину перевіривши свої знання.</p>
        </div>
    )
}