import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import { useTheme } from '/src/Hooks/ThemeContext'
import { useParams } from "react-router-dom";
import styles from './lesson.module.less'
import LessonModule from "./CourseModule/LessonModule";
import LessonLink from "./LessonLink/LessonLink";
import Modal from '/src/components/Common/Modal/Modal';
import Button from '/src/components/Common/Button/Button';


const course = {
    title: 'Fictive course',
    modules: [
        {
            id: 1,
            title: 'Основи англійської мови',
            mapImg: '/src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Вступ до граматики', isComplete: true, countTask: 5 },
                { id: 2, title: 'Основні слова та фрази', isComplete: true, countTask: 7 },
                { id: 3, title: 'Вживання дієслів', isComplete: true, countTask: 4 },
                { id: 4, title: 'Часи в англійській', isComplete: false, countTask: 6 },
                { id: 5, title: 'Запитання та відповіді', isComplete: false, countTask: 3 },
                { id: 6, title: 'Короткі речення', isComplete: false, countTask: 8 },
            ]
        },
        {
            id: 2,
            title: 'Лексика та словниковий запас',
            mapImg: '/src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Повсякденні слова', countTask: 5 },
                { id: 2, title: 'Теми: їжа', countTask: 4 },
                { id: 3, title: 'Теми: подорожі', countTask: 6 },
                { id: 4, title: 'Теми: погода', countTask: 7 },
                { id: 5, title: 'Антоніми та синоніми', countTask: 4 },
                { id: 6, title: 'Вивчення фраз', countTask: 5 },
            ]
        },
        {
            id: 3,
            title: 'Граматика на прикладах',
            mapImg: '/src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Структура речень', countTask: 6 },
                { id: 2, title: 'Вживання артиклів', countTask: 5 },
                { id: 3, title: 'Прийменники', countTask: 7 },
                { id: 4, title: 'Прикметники та прислівники', countTask: 4 },
                { id: 5, title: 'Заперечення', countTask: 3 },
                { id: 6, title: 'Складні речення', countTask: 5 },
            ]
        },
        {
            id: 4,
            title: 'Слухання та вимова',
            mapImg: '/src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Вимова звуків', countTask: 4 },
                { id: 2, title: 'Слухові вправи', countTask: 6 },
                { id: 3, title: 'Аудіо вправи', countTask: 5 },
                { id: 4, title: 'Розуміння на слух', countTask: 7 },
                { id: 5, title: 'Повторення фраз', countTask: 3 },
                { id: 6, title: 'Діалоги', countTask: 6 },
            ]
        },
        {
            id: 5,
            title: 'Читання та письмо',
            mapImg: '//src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Читання текстів', countTask: 5 },
                { id: 2, title: 'Написання речень', countTask: 6 },
                { id: 3, title: 'Огляд граматики', countTask: 4 },
                { id: 4, title: 'Складення історій', countTask: 7 },
                { id: 5, title: 'Анотації', countTask: 5 },
                { id: 6, title: 'Есе', countTask: 6 },
            ]
        },
        {
            id: 6,
            title: 'Практика та повторення',
            mapImg: '//src/img/Content/map.png',
            lessons: [
                { id: 1, title: 'Повторення граматики', countTask: 6 },
                { id: 2, title: 'Розмовна практика', countTask: 5 },
                { id: 3, title: 'Пробні тести', countTask: 7 },
                { id: 4, title: 'Вправи на повторення', countTask: 4 },
                { id: 5, title: 'Групова робота', countTask: 6 },
                { id: 6, title: 'Зворотній зв\'язок', countTask: 3 },
            ]
        },
    ]
}
const positions = {
    1: { top: '100px', left: '100px' },
    2: { top: '250px', left: '50px' },
    3: { top: '400px', left: '300px' },
    4: { top: '550px', left: '100px' },
    5: { top: '700px', left: '300px' },
    6: { top: '850px', left: '350px' },
};

export default function Lessons() {
    const [currentModule, setCurrentModule] = useState(course.modules[0]);
    const [currentLesson, setCurrentLesson] = useState(currentModule.lessons[0])
    const [isOpenModal, setIsOpenModal] = useState(false);
    const { id: courseId } = useParams();
    const { theme } = useTheme();


    useEffect(() => {
        //TODO: Здесь нужно добавить загрузку модуля по courseId, если она необходима
        setCurrentModule(course.modules[0]);
        setCurrentLesson(currentModule.lessons[0])
        //TODO: в дальнейшем полученый модуль будет устанавливаться как текущий
    }, [courseId]);

    const openModal = () => {
        setIsOpenModal(true);
    };

    const closeModal = () => {
        setIsOpenModal(false);
    };

    return (
        <div className={styles.lessons}>
            <div className={styles.lessons__flexContainer}>
                <div className={`${"block__container"} ${styles.lessons__lessonsMenu}`}>
                    <div className={styles.lesonsMenu__modules}>
                        {course.modules.map((module) =>
                            <LessonModule
                                key={module.id}
                                module={module}
                                onModuleSelect={() => setCurrentModule(module)}
                                currentModuleId={currentModule.id}
                            />)
                        }
                    </div>
                </div>
                <div className={`${"block__container"} ${styles.lessons__lessonsMap}`}>
                    <div className={styles.lessons__mapImage}>
                        <img src={currentModule.mapImg} alt="Module Map" />
                        {currentModule.lessons.map((lesson) => {
                            const position = positions[lesson.id];
                            return (
                                <LessonLink
                                    key={lesson.id}
                                    lesson={lesson}
                                    currentLesson={currentLesson}
                                    onLessonSelect={() => setCurrentLesson(lesson)}
                                    style={{ position: 'absolute', top: position ? position.top : '0px', left: position ? position.left : '0px', }}
                                    openModal={openModal}
                                />
                            );
                        })}
                    </div>
                </div>
            </div>
            {isOpenModal && (
                <>
                    <div className={styles.modalOverlay} onClick={closeModal} />
                    <Modal>
                        <div className={`${styles.modal} ${theme === 'dark' ? styles.modal_dark : styles.modal_light}`}>
                            <h4 className={styles.modal__title}>Оберіть з чого почати</h4>
                            <div className={styles.modal__flexContainer}>
                                <Link to={`/course/${encodeURIComponent(course.title)}/module/${encodeURIComponent(currentModule.title)}/lessonTheory/${currentLesson.id}`}>
                                    <Button click={closeModal}>Теорія</Button>
                                </Link>
                                <Link to={`/course/${encodeURIComponent(course.title)}/module/${encodeURIComponent(currentModule.title)}/lessonPractice/${currentLesson.id}`}>
                                    <Button click={closeModal}>Практика</Button>
                                </Link>
                            </div>
                        </div>
                    </Modal>
                </>
            )}
        </div>
    );
}