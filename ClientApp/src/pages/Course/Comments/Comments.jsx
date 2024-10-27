import { useTheme } from '/src/Hooks/ThemeContext'
import Sorting from '/src/components/Common/Sorting/Sorting'
import Button from '/src/components/Common/Button/Button'
import styles from './comments.module.less'

const comments = [
    {
        userId: '1',
        userName: 'Fictive name 1',
        comment: 'Цей курс був саме тим, що мені потрібно для початку! Простий та зрозумілий, пояснення на рівні новачка.',
        userIcon: '/src/img/fictive/userIcon1.png',
        countLike: '21',
        countDiselike: '32',
    },
    {
        userId: '2',
        userName: 'Fictive name 2',
        comment: 'Матеріал подається структуровано, і кожне нове заняття доповнює попереднє. Дуже корисно для тих, хто хоче закласти хорошу основу в англійській мові.',
        userIcon: '/src/img/fictive/userIcon2.png',
        countLike: '1',
        countDiselike: '0',
    },
    {
        userId: '3',
        userName: 'Fictive name 3',
        comment: 'Рекомендую цей курс всім, хто тільки починає вивчати англійську. Багато прикладів та практики допомагають краще запам\'ятовувати слова та фрази.',
        userIcon: '/src/img/fictive/userIcon3.png',
        countLike: '29',
        countDiselike: '4',
    },
    {
        userId: '4',
        userName: 'Fictive name 4',
        comment: 'Навчальний матеріал подається чітко й без зайвого ускладнення. Чудова можливість засвоїти основи англійської для новачків.',
        userIcon: '/src/img/fictive/userIcon4.png',
        countLike: '11',
        countDiselike: '5',
    },
    {
        userId: '5',
        userName: 'Fictive name 5',
        comment: 'Занадто простий курс. Якщо у вас вже є хоч трохи знань англійської, він не додасть нічого нового. Підходить тільки для абсолютних новачків.',
        userIcon: '/src/img/fictive/userIcon5.png',
        countLike: '67',
        countDiselike: '4',
    },
    {
        userId: '6',
        userName: 'Fictive name 6',
        comment: 'Дуже допоміг мені у вивченні базових фраз та правил граматики. Інтерактивні завдання дозволяють добре закріпити знання!',
        userIcon: '/src/img/fictive/userIcon6.png',
        countLike: '14',
        countDiselike: '5',
    },
]

export default function Comments() {
    const { theme } = useTheme()
    return (
        <div className={`${'block__container'} ${styles.comments}`}>
            <div className={styles.comments__writecomment}>
                <div className={styles.comments__img}>
                    <img src="/src/img/fictive/userIconNull.svg" alt="" />
                </div>
                <form action="" className={styles.comments__form}>
                    <input type="text" placeholder='Write comment' className={styles.comments__input} />
                    <div className={styles.comments__buttonActions}>
                        <Button>Скасувати</Button>
                        <Button>Відправити</Button>
                    </div>
                </form>
            </div>
            <Sorting />
            {
                Object.keys(comments).map((userId) => {
                    const comment = comments[userId]
                    return (
                        <div className={styles.comentsContainer}>
                            <div key={userId} className={styles.comment}>
                                <div className={styles.comment__icon}>
                                    <img src={comment.userIcon} alt="User Icon" />
                                </div>
                                <div className="comment__content">
                                    <div className={styles.comment__userName}>{comment.userName}</div>
                                    <div className={styles.comment__comment}>{comment.comment}</div>
                                    <div className={styles.comment__reaction}>
                                        <div className={styles.comment__like}>
                                            {
                                                theme === "dark"
                                                    ? <img src="/src/img/general/comments/dark-like.svg" alt="Like" />
                                                    : <img src="/src/img/general/comments/light-like.svg" alt="Like" />
                                            }
                                            <div className={styles.comment__countLike}>{comment.countLike}</div>
                                        </div>
                                        <div className={styles.comment__diselike}>
                                            {
                                                theme === "dark"
                                                    ? <img src="/src/img/general/comments/dark-diselike.svg" alt="Diselike" />
                                                    : <img src="/src/img/general/comments/light-diselike.svg" alt="Diselike" />
                                            }
                                            <div className={styles.comment__countDiselike}>{comment.countDiselike}</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    )
                })
            }
        </div>
    );
}