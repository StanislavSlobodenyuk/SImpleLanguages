import styles from './header.module.less'

export default function Name() {
    return (
        <div className={styles.header__miniProfile}>
            <div className={styles.header__userInformation}>
                <div className={styles.header__userIcon}>
                    <img src='/src/img/fictive/userIconNull.svg'></img>
                </div>
                <div className={styles.header__text}>
                    <div className={styles.header__userName}>user name</div>
                    <div className={styles.header__selectCourse}>Вибраний курс</div>
                </div>
            </div>
            <div className={styles.header__values}>
                <div className={styles.header__raiting}>
                    <div className={styles.header__value}>1</div>
                    <img src="/src/img/general/raiting.png" alt="Rainting" />
                </div>
                <div className={styles.header__money}>
                    <div className={styles.header__value}>2</div>
                    <img src="/src/img/general/money.png" alt="Game money 1" />
                </div>
                <div className={styles.header__money}>
                    <div className={styles.header__value}>3</div>
                    <img src="/src/img/general/money.png" alt="Game money 1" />
                </div>
            </div>
        </div>
    );
}