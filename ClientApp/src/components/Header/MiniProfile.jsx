import styles from './header.module.less'

export default function Name() {
    const user = JSON.parse(localStorage.getItem("user"));
    return (
        <div className={styles.headerMiniProfile}>
            <div className={styles.headerUserInformation}>
                <div className={styles.headerUserIcon}>
                    <img src='/src/img/fictive/userIconNull.svg'></img>
                </div>
                <div className={styles.headerText}>
                    {user && user.userName && (
                        <div className={styles.headerUserName}>{user.userName}</div>
                    )}
                    <div className={styles.headerSelectCourse}>Level 0. 10/120 xp</div>
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