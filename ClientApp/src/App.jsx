import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Sidebar from "./components/Sidebar/Sidebar";
import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import { ThemeProvider } from "./Hooks/ThemeContext";
import LandingPage from './pages/LandingPage/LandingPage';
import Courses from './pages/Courses/Courses';
import { useTheme } from './Hooks/ThemeContext';

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
                        {/* <Route path="/course" element={<Course />} />
                        <Route path="/lessons" element={<Lessons />} />
                        <Route path="/lessonTheory" element={<LessonTheory />} />
                        <Route path="/lessonPractice" element={<LessonPractice />} />
                        <Route path="/lessonPractice" element={<LessonResult />} /> */}

                        <Route path="/" element={<Navigate to="/landing" />} />
                    </Routes>
                </main>
                <Footer />
            </div>
        </>
    );
}