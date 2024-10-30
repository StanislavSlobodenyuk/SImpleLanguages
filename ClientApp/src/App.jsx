import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import { useTheme } from './Hooks/ThemeContext';
import { ThemeProvider } from "./Hooks/ThemeContext";
import Sidebar from "./components/Sidebar/Sidebar";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import LandingPage from './pages/LandingPage/LandingPage';
import Courses from './pages/Courses/Courses';
import Course from './pages/Course/Course';
import Lessons from './pages/Lessons/Lessons';
import LessonTheory from './pages/LessonTheory/LessonTheory';
import LessonPractice from './pages/LessonPractice/LessonPractice';




export default function App() {
    return (
        <Router>
            <ThemeProvider>
                <AppContent />
            </ThemeProvider>
        </Router>
    );
}

function AppContent() {
    const { theme } = useTheme();

    return (
        <>
            <Sidebar />
            <div className={"content__container"}>
                <Header />
                <main className={theme === 'dark' ? "darkMain" : "lightMain"}>
                    <Routes>
                        <Route path="/landing" element={<LandingPage />} />
                        <Route path="/courses" element={<Courses />} />
                        <Route path="/course/:id" element={<Course />} />
                        <Route path="/course/:id/lessons" element={<Lessons />} />
                        <Route path="/course/:courseId/lessonTheory/:lessonId" element={<LessonTheory />} />
                        <Route path="/course/:courseId/lessonPractice/:lessonId" element={<LessonPractice />} />
                        {/*<Route path="/lessonPractice" element={<LessonResult />} /> */}

                        <Route path="/" element={<Navigate to="/landing" />} />
                    </Routes>
                </main>
                <Footer />
            </div>
        </>
    );
}