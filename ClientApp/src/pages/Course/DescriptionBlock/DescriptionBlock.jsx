import Button from '/src/components/Common/Button/Button'
import styles from './descriptionBlock.module.less'
import { Link } from 'react-router-dom';
import { levelMapping, contriesImageMapping } from '/src/Mapping/Mappinig';
import { useTheme } from '/src/Hooks/ThemeContext';

export default function DescriptionBlock({ course }) {
    const { theme, changeTheme } = useTheme();
    return (
        <div class="block-container">
            <div className={`${styles.course} ${theme === 'dark' ? 'dark-theme' : 'light-theme'}`}>
                <div className={styles.courseFlexContainer}>
                    <h3 className={styles.courseTitle}>{course.title}</h3>
                    <div className={styles.courseImg}>
                        <img src={contriesImageMapping[course.language]} alt="Course image" />
                    </div>
                    <div className={styles.courseLevel}>Рівень: {levelMapping[course.level]}</div>
                </div>
                <div className={styles.courseDescription}>{course.description}</div>
                <div className={styles.courseThemes}>Теми: привітання та знайомства, особиста інформація, сім’я та друзі, числа та дати, основні дії та дієслова  </div>
                <div className={styles.courseGrammarThemes}>Граматичні теми: алфавіт та вимова, займенники, дієслово "to be", знайомство з Present Simple: позитивні, заперечувальні питальні речення, артиклі, іменники в однині та множині,  прості прикметники та їх порядок, прийменники місця, прості часові вирази та прийменники часу</div>
                <div className={styles.stories}>Історії: 20+ історій  </div>
                <div className={styles.additional}>А ще близько 400 слів, 1000 словосполучень та 8 граматичних правил, які будуть додані до твого словника</div>
                <Link to={`/course/${course.id}/lessons`}>
                    <Button>Розпочати</Button>
                </Link>
            </div>
        </div>
    );
}