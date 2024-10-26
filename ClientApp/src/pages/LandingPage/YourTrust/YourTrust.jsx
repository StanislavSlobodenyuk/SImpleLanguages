import Review from './Review/review';
import { reviews } from './dataReviews'
import styles from './yourTrust.module.less'

export default function YourTrust() {
    return (
        <div>
            <div className={`${'block__container'} ${styles.yourTrust}`}>
                <h2 className={styles.yourTrust__title}>Ваша довіра та підтримка, для нас є найважливішим</h2>
                <div className={styles.yourTrust__reviews}>
                    {
                        reviews.map((review, index) => (
                            <Review key={index} {...review} />
                        ))
                    }
                </div>
                <div>Загальний рейтинг на основі <span>N</span> кількості користувачів <span>M</span></div> {/*TODO: N -к ількість користувачів  та  М - рейтинг платформи взяти с БД*/}
            </div>
        </div>
    );
}