import styles from './imageWithCaption.module.less'

export default function ImageWithCaption({ src, caption, isExist, location }) {
    return (
        <div className={styles.item}>
            <div className={styles.img}>
                <img src={src} alt="Course" title="Зображення взято з ресурсу https://icons8.com" />
            </div>
            <div className={styles.caption}>{caption}</div>
            {
                location === 'LandingPage' && (
                    isExist ? (
                        <a href="#" className={styles.isExistText}>Переглянути</a>
                    ) : (
                        <a href="#" className={styles.isExistText}>Ще в розробці</a>
                    )
                )
            }
        </div>
    )
}