import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import { useTheme } from '/src/Hooks/ThemeContext'
import { useParams } from "react-router-dom";
import styles from './lesson.module.less'
import LessonModule from "./CourseModule/LessonModule";
import LessonLink from "./LessonLink/LessonLink";
import Modal from '/src/components/Common/Modal/Modal';
import Button from '/src/components/Common/Button/Button';
import { FetchCourseModules } from "/src/api/CourseApi/CourseApi";

const positions = {
    1: { top: '100px', left: '100px' },
    2: { top: '250px', left: '50px' },
    3: { top: '400px', left: '300px' },
    4: { top: '550px', left: '100px' },
    5: { top: '700px', left: '300px' },
    6: { top: '850px', left: '350px' },
};

export default function Lessons() {
    const { id: courseId } = useParams()
    const { theme } = useTheme()
    const [isModules, setIsModules] = useState([])
    const [currentModule, setCurrentModule] = useState({})
    const [currentLesson, setCurrentLesson] = useState({})
    const [error, setError] = useState(null)
    const [isOpenModal, setIsOpenModal] = useState(false)

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await FetchCourseModules({ courseId })
                setIsModules(data)

                if (data.length > 0) {
                    setCurrentModule(data[0])
                    if (data[0].Lessons && data[0].Lessons.length > 0) {
                        setCurrentLesson(data[0].Lessons[0])
                    }
                }
            } catch (error) {
                setError('Failed to fetch modules')
            }
        };
        fetchData();
    }, [courseId]);

    if (error) {
        return <div>{error}</div>;
    }

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
                        {isModules.map((module) =>
                            <LessonModule
                                key={module.id}
                                module={module}
                                onModuleSelect={() => setCurrentModule(module)}
                                currentModuleId={currentModule.id}
                            />
                        )}
                    </div>
                </div>
                <div className={`${"block__container"} ${styles.lessons__lessonsMap}`}>
                    <div className={styles.lessons__mapImage}>
                        <img src={currentModule.pathToMap} alt="Module Map" />
                        {currentModule.lessons && currentModule.lessons.map((lesson) => {
                            const position = positions[lesson.id];
                            return (
                                <LessonLink
                                    key={lesson.id}
                                    lesson={lesson}
                                    currentLesson={currentLesson}
                                    onLessonSelect={() => setCurrentLesson(lesson)}
                                    style={{
                                        position: 'absolute',
                                        top: position ? position.top : '0px',
                                        left: position ? position.left : '0px',
                                    }}
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
                                <Link to={`/course/${courseId}/module/${encodeURIComponent(currentModule.title)}/lessonTheory/${currentLesson.id}`}>
                                    <Button click={closeModal}>Теорія</Button>
                                </Link>
                                <Link to={`/course/${courseId}/module/${encodeURIComponent(currentModule.title)}/lessonPractice/${currentLesson.id}`}>
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