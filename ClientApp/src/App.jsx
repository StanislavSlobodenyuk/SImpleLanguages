import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import { useState } from 'react';
import { useTheme } from './Hooks/ThemeContext';
import { ThemeProvider } from "./Hooks/ThemeContext";
import { Header, Footer, Sidebar, ProtectedRoute } from './components';
import { LandingPage, Courses, Course, Lessons, LessonTheory, LessonPractice, LessonResult, LoginPage } from './pages';


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
    const [isAuthenticated, setIsAuthenticated] = useState(true);
    const { theme } = useTheme();

    const protectedRoutes = [
        { path: "/courses", element: <Courses /> },
        { path: "/course/:id", element: <Course /> },
        { path: "/course/:id/lessons", element: <Lessons /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonTheory/:lessonId", element: <LessonTheory /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonPractice/:lessonId", element: <LessonPractice /> },
        { path: "/course/:courseTitle/module/:moduleTitle/lessonPractice/:lessonId/result", element: <LessonResult /> }
    ];

    return (
        <>
            <Sidebar authenticated={isAuthenticated} />
            <div className={"content__container"}>
                <Header authenticated={isAuthenticated} />
                <main className={theme === 'dark' ? "darkMain" : "lightMain"}>
                    <Routes>
                        <Route path="/landing" element={<LandingPage />} />
                        <Route path="/login" element={<LoginPage />} />
                        {protectedRoutes.map((route, index) => (
                            <Route
                                key={index}
                                path={route.path}
                                element={
                                    <ProtectedRoute authenticated={isAuthenticated}>
                                        {route.element}
                                    </ProtectedRoute>
                                }
                            />
                        ))}
                    </Routes>
                </main>
                <Footer />
            </div>
        </>
    );
}