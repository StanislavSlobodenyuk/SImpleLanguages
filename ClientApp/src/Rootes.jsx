import { LandingPage, Courses, Course, Lessons, LessonTheory, LessonPractice, LessonResult } from './pages';
import { LoginPage, RegisterPage } from './auth/index'

const routes = {
    public: [
        { path: "/", element: <LandingPage /> },
        { path: "/login", element: <LoginPage /> },
        { path: "/register", element: <RegisterPage /> },
    ],
    protected: [
        { path: "/courses", element: <Courses /> },
        { path: "/course/:id", element: <Course /> },
        { path: "/course/:id/lessons", element: <Lessons /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonTheory/:lessonId", element: <LessonTheory /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonPractice/:lessonId", element: <LessonPractice /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonPractice/:lessonId/result", element: <LessonResult /> }
    ]
};

export default routes;