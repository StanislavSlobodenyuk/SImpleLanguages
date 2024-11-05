import Button from '/src/components/Common/Button/Button'
import styles from './descriptionBlock.module.less'
import { Link } from 'react-router-dom';
import { levelMapping, contriesImageMapping } from '/src/Mapping/Mappinig'

export default function DescriptionBlock({ course }) {
    return (
        <div className={`${styles.course} ${"block__container"}`}>
            <div className={styles.course__flexContainer}>
                <h3 className={styles.course__title}>{course.title}</h3>
                <div className={styles.course__img}>
                    <img src={contriesImageMapping[course.language]} alt="Course image" />
                </div>
                <div className={styles.course__level}>Рівень: {levelMapping[course.level]}</div>
            </div>
            <div className={styles.course__description}>{course.description}</div>
            <div className={styles.course__themes}>Теми: привітання та знайомства, особиста інформація, сім’я та друзі, числа та дати, основні дії та дієслова  </div>
            <div className={styles.course__grammarThemes}>Граматичні теми: алфавіт та вимова, займенники, дієслово "to be", знайомство з Present Simple: позитивні, заперечувальні питальні речення, артиклі, іменники в однині та множині,  прості прикметники та їх порядок, прийменники місця, прості часові вирази та прийменники часу</div>
            <div className={styles.stories}>Історії: 20+ історій  </div>
            <div className={styles.additional}>А ще близько 400 слів, 1000 словосполучень та 8 граматичних правил, які будуть додані до твого словника</div>
            <Link to={`/course/${course.id}/lessons`}>
                <Button>Розпочати</Button>
            </Link>
        </div>
    );
}