import CourseCard from '../../../components/Common/CourseCard/CourseCard';
import styles from './recommends.module.less'

const courses = [
    // фіктивні данні для відображення вебу потім видаляться 
    {
        id: 1,
        title: 'Основи англійської мови',
        description: 'Цей курс охоплює основи англійської мови для початківців.',
        language: 'english',
        level: 'beginner',
        numberLessons: 30,
        cost: 0,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 2,
        title: 'Англійська для туристів',
        description: 'Курс з англійської для тих, хто подорожує.',
        language: 'english',
        level: 'elementary',
        numberLessons: 25,
        cost: 75,
        image: '/src/img/Content/AboutService.png'
    },
    {
        id: 3,
        title: 'Поглиблене вивчення української мови',
        description: 'Цей курс призначений для тих, хто хоче покращити свої знання української.',
        language: 'ukrainian',
        level: 'intermediate',
        numberLessons: 40,
        cost: 120,
        image: '/src/img/Content/AboutService.png'
    },
]

export default function Recommends() {
    return (
        <div className={`${'block__container'} ${styles.recommends}`}>
            <h3 className={styles.recommends__title}>Схожі курси</h3>
            <div className={styles.recommends__courses}>
                {
                    courses.map(course => (
                        <CourseCard course={course} />
                    ))
                }
            </div>
        </div>
    );
}