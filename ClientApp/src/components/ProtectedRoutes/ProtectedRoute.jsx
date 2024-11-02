import { Navigate } from 'react-router-dom';

const ProtectedRoute = ({ children, authenticated }) => {

    if (!authenticated) {
        console.log("login")
        return <Navigate to="/login" replace />;
    }

    return children; // Если авторизован, возвращаем дочерние компоненты
};
export default ProtectedRoute