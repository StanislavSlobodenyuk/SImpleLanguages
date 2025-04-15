import { BrowserRouter as Router, Routes, Route, useLocation, useNavigate } from 'react-router-dom';
import { ThemeProvider, useTheme } from './Hooks/ThemeContext';
import { Header, Footer, Sidebar } from './components';
import { ProtectedRoute } from './auth/index.js';
import { useSelector, useDispatch } from 'react-redux';
import { useEffect, useState } from 'react';
import { initAuthThunk } from './Redux/authSlice.js';
import routes from './Rootes';

export default function App() {
    return (
        <Router>
            <ThemeProvider>
                <AuthLoader />
            </ThemeProvider>
        </Router>
    );
}

function AuthLoader() {
    const dispatch = useDispatch();
    const [authReady, setAuthReady] = useState(false);

    useEffect(() => {
        const init = async () => {
            await dispatch(initAuthThunk());
            setAuthReady(true);
        };

        init();
    }, [dispatch]);

    if (!authReady) return null;
    
    return <AppContent />;
}

function AppContent() {
    const location = useLocation();
    const navigate = useNavigate();
    const { isAuthenticated } = useSelector((state) => state.auth);
    const { theme } = useTheme();

    const isMinimalLayout = ['/login', '/register'].includes(location.pathname);

    useEffect(() => {
        navigate(location.pathname, { replace: true });
    }, [location.pathname, navigate]);

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
}

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
