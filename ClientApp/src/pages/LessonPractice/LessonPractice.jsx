import { useParams } from "react-router-dom";
import styles from './lessonPractice.module.less'
import SimpleQuestion from "./QuestionsType/SimpleQuestion";
import AudioQuestion from "./QuestionsType/AudioQuestions";
import TextQuestion from "./QuestionsType/TextQuestion";
import ImageQuestion from "./QuestionsType/ImageQuestion";
import Button from '/src/components/Common/Button/Button'

const answerType = ['radio', 'checkbox', 'input', 'writing']
const questionType = ['simple', 'audio', 'image', 'text']

const practice = {
    questions: [
        {
            id: 1,
            type: questionType[0],
            questionText: 'Який переклад слова "family"',
            answerType: answerType[0],
            answers: ['Сім\'я', 'Дерево', 'Батько', 'Мати'],
            rightAnswer: 'Сім\'я'
        },
        {
            id: 2,
            type: questionType[1],
            questionText: 'Прослухайте та перекладіть данний фрагмент',
            answerType: answerType[0],
            audioUrl: '/src/audioTest/testSound.mp3',
            answers: ['Hello my name`s Den', 'Good evening Den', 'Bye Den', 'How are you Den?'],
            rightAnswer: 'Hello my name`s Den'
        },
        {
            id: 3,
            type: questionType[3],
            questionText: 'Прочитайте текст та виберіть всі вірні відповіді. Що подаболася Анні?',
            answerType: answerType[1],
            text: 'Anna likes to read books. She reads every day after school. Her favorite book is about animals. She also loves to draw pictures of her favorite animals. Anna wants to become a vet and help animals when she grows up.',
            answers: ['Play soccer', 'Read books', 'Draw pictures', 'Cook food', 'Sing songs'],
            rightAnswer: ['Read books', 'Draw pictures']
        },
        {
            id: 4,
            type: questionType[2],
            questionText: 'Що ви бачите на картинці?',
            answerType: answerType[2],
            images: ['/src/img/Content/cat.png'],
            answers: [],
            rightAnswer: 'cat'
        },
        {
            id: 5,
            type: questionType[0],
            questionText: 'Напишіть 5 речень про себе використовуючи слова які вивчили в цьому уроці',
            answerType: answerType[3],
            answers: [],
            rightAnswer: ''
        },
    ]
}

const TaskRender = ({ question }) => {
    switch (question.type) {
        case 'simple':
            return <SimpleQuestion question={question} />
        case 'audio':
            return <AudioQuestion question={question} />
        case 'text':
            return <TextQuestion question={question} />
        case 'image':
            return <ImageQuestion question={question} />
    }
}

export default function LessonPractice() {
    const { courseTitle, moduleTitle, lessonId } = useParams()
    return (
        <div className={` ${styles.practice}`}>
            <h4 className={styles.practice__title} >Курс "{courseTitle}" модуль "{moduleTitle}" урок {lessonId}</h4>
            <div className={styles.practice__questions}>
                {practice.questions.map((question) =>
                    <div key={question.id} className={`${styles.practice__questions} ${"block__container"}`}>
                        <TaskRender question={question} />
                    </div>
                )}
            </div>
            <div className={styles.practice__buttonResults}>
                <Button>Переглянути результати</Button>
            </div>
        </div>
    );
}