import Button from '../../../components/Common/Button/Button'
import styles from './aboutService.module.less'

export default function AboutService() {
    return (
        <div className={`${"block-container"} ${styles.aboutService}`}>
            <div className={styles.aboutServiceContent}>
                <h1 className={styles.aboutServiceTitle}>Simple Languages — це сучасна платформа для ефективного та зручного вивчення іноземних мов. </h1>
                <p className={styles.aboutServiceText}>Проект Simple Langueges пропонує вам структуровані курси, адаптовані під різні рівні підготовки: від початківців до досвідчених мовців. Кожен урок супроводжується інтерактивними завданнями, які допоможуть закріпити нові знання на практиці. Платформа також підтримує різні формати навчання, включаючи аудіо- та відеоматеріали, що дозволяють розвивати не лише граматику та лексику, але й слухові та мовленнєві навички. Приєднуйтесь до нашої спільноти учнів та вдосконалюйте свої мовні здібності щодня!</p>
                <div className=""><Button>Зареєструватись</Button></div>
            </div>
            <div className={styles.aboutServiceImage}>
                <img src="/src/img/Content/AboutService.png" />
            </div>
        </div>
    )
}