import { Link } from "react-router-dom";
import { json, useParams } from "react-router-dom";
import Textblock from "./TypesTheoryBlock/TextBlock";
import Listblock from "./TypesTheoryBlock/ListBlock";
import Tableblock from "./TypesTheoryBlock/TableBlock";
import Imageblock from "./TypesTheoryBlock/ImageBlock";
import Button from '/src/components/Common/Button/Button'
import styles from './lessonTheory.module.less'

export const fakeLectureBlocks = [
    {
        id: 1,
        blockType: 'text',
        title: '',
        content: 'Тут дуже багато контенту про англійську мову і все інше тут дуже багато контенту про англійську мову і все інше  тут дуже багато контенту про англійську мову і все інше тут дуже багато контенту про англійську мову і все інше  тут дуже багато контенту про англійську мову і все інше  ',
        image: null,
    },
    {
        id: 2,
        blockType: 'table',
        title: 'Частини мови — це основні елементи, які будують речення. Вони включають такі основні групи:',
        content: JSON.stringify([
            {
                term: 'Іменники (Nouns)',
                usage: 'Позначають людей, місця, предмети або ідеї',
                example: 'dog (собака), city (місто), love (любов)'
            },
            {
                term: 'Дієслова (Verbs)',
                usage: 'Позначають дії або стани',
                example: 'run (бігти), think (думати), be (бути)'
            },
            {
                term: 'Прикметники (Adjectives)',
                usage: 'Описують іменники',
                example: 'big (великий), blue (синій), happy (щасливий)'
            },
            {
                term: 'Прислівники (Adverbs)',
                usage: 'Описують дієслова, прикметники або інші прислівники',
                example: 'quickly (швидко), very (дуже), well (добре)'
            },
            {
                term: 'Займенники (Pronouns)',
                usage: 'Замінюють іменники для уникнення повторень',
                example: 'he (він), they (вони), it (це)'
            },
            {
                term: 'Прийменники (Prepositions)',
                usage: 'Виражають відношення між предметами',
                example: 'in (в), on (на), at (біля)'
            },
            {
                term: 'Сполучники (Conjunctions)',
                usage: 'З\'єднують частини речення',
                example: 'and (і), but (але), or (або)'
            },
            {
                term: 'Вигуки (Interjections)',
                usage: 'Використовуються для вираження емоцій',
                example: 'wow (ого), ouch (ай)'
            }
        ]),
        image: null,

    },
    {
        id: 3,
        blockType: 'list',
        title: 'У англійській мові є три основні часові форми: минулий, теперішній та майбутній часи. Кожен з них має просту, тривалу, досконалу і досконалу тривалу форму.',
        content: JSON.stringify(['Теперішній час (Present): I play (Я граю)', 'Минулий час (Past): I played (Я грав)', 'Майбутній час (Future): I will play (Я буду грати)']),
        image: null,
    },
    {
        id: 4,
        blockType: 'image',
        title: 'Вживання артиклів (Articles).',
        content: '',
        images: [{ id: 1, url: '/src/img/Content/fictiveArticles.jpg', alt: 'Grammar Image 1' }],
    },
];

const BlockRender = ({ block }) => {
    switch (block.blockType) {
        case 'text':
            return <Textblock block={block} />
        case 'image':
            return <Imageblock block={block} />
        case 'table':
            return <Tableblock block={block} />
        case 'list':
            return <Listblock block={block} />
        default: return null
    }
}

export default function LessonTheory() {
    const { courseTitle, moduleTitle, lessonId } = useParams()
    //TODO: тут з бд по уроку будуть братися теоричні блоки та від їх кількості появлятися контент
    return (
        <div className={`${"block__container"} ${styles.theory}`}>
            <h4 className={styles.theory__title} >Курс "{courseTitle}" модуль "{moduleTitle}" урок {lessonId}</h4>
            {fakeLectureBlocks.map((block) =>
                <div key={block.id} className="">
                    <BlockRender block={block} />
                </div>
            )}

            <div className={styles.theory__button}>
                <Link to={`/course/${encodeURIComponent(courseTitle)}/module/${encodeURIComponent(moduleTitle)}/lessonPractice/${lessonId}`}>
                    <Button>Розпочати практику</Button>
                </Link>
            </div>
        </div>
    );
}
