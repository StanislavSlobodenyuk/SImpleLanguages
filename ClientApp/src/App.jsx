import { BrowserRouter as Router, Route, Routes, useLocation } from 'react-router-dom';
import { ThemeProvider, useTheme } from './Hooks/ThemeContext';
import { Header, Footer, Sidebar } from './components';
import { ProtectedRoute } from './auth/index.js';
import { useSelector } from 'react-redux';
import routes from './Rootes'
import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { refreshThunk } from './Redux/authSlice.js';

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
    const dispatch = useDispatch();
    const isAuthenticated = useSelector((state) => state.auth.isAuthenticated);
    const { theme } = useTheme();
    const location = useLocation();
    const isMinimalLayout = ['/login', '/register'].includes(location.pathname);

    useEffect(() => {
        const accessToken = localStorage.getItem("accesToken");
        const refreshToken = localStorage.getItem("refreshToken");

        if (accessToken && refreshToken) {
            dispatch(refreshThunk({ accessToken, refreshToken }));
        }
    }, [dispatch])

    return (
        <div className={isMinimalLayout ? "for-register-and-login" : "default-layout"}>
            {!isMinimalLayout && <Sidebar authenticated={isAuthenticated} />}
            <div className="content-container">
                {!isMinimalLayout && <Header authenticated={isAuthenticated} />}
                <MainContent theme={theme} isAuthenticated={isAuthenticated} />
                {!isMinimalLayout && <Footer />}
            </div>
        </div>
    );

    function MainContent({ theme, isAuthenticated }) {
        return (
            <main className={theme === 'dark' ? "dark-main" : "light-main"}>
                <Routes>
                    {routes.public.map(({ path, element }, index) => (
                        <Route key={index} path={path} element={element} />
                    ))}
                    {routes.protected.map(({ path, element }, index) => (
                        <Route
                            key={index}
                            path={path}
                            element={
                                <ProtectedRoute authenticated={isAuthenticated}>
                                    {element}
                                </ProtectedRoute>
                            }
                        />
                    ))}
                </Routes>
            </main>
        );
    }
}
