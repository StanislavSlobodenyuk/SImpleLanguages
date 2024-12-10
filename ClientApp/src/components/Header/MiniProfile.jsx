import styles from './header.module.less'

export default function Name() {
    return (
        <div className={styles.headerMiniProfile}>
            <div className={styles.headerUserInformation}>
                <div className={styles.headerUserIcon}>
                    <img src='/src/img/fictive/userIconNull.svg'></img>
                </div>
                <div className={styles.headerText}>
                    <div className={styles.headerUserName}>user name</div>
                    <div className={styles.headerSelectCourse}>Вибраний курс</div>
                </div>
            </div>
            <div className={styles.headerValues}>
                <div className={styles.headerRaiting}>
                    <div className={styles.headerValue}>1</div>
                    <img src="/src/img/general/raiting.png" alt="Rainting" />
                </div>
                <div className={styles.headerMoney}>
                    <div className={styles.headerValue}>2</div>
                    <img src="/src/img/general/money.png" alt="Game money 1" />
                </div>
                <div className={styles.headerMoney}>
                    <div className={styles.headerValue}>3</div>
                    <img src="/src/img/general/money.png" alt="Game money 1" />
                </div>
            </div>
        </div>
    );
}