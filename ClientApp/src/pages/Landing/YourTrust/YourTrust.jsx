import Review from './Review/review';
import { reviews } from './dataReviews'
import styles from './yourTrust.module.less'
import { useTheme } from '/src/Hooks/ThemeContext'

export default function YourTrust() {
    const { theme } = useTheme();
    return (
        <div>
            <div className={`${'block__container'} ${styles.yourTrust}`}>
                <h2 className={`${theme === 'dark' ? 'light' : 'dark'}`}>Ваша довіра та підтримка, для нас є найважливішим</h2>
                <div className={styles.yourTrustReviews}>
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
} styles.yourTrustTitle