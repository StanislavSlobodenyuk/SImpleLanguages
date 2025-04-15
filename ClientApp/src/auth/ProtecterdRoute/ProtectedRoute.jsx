import { Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';

export default function ProtectedRoute({ children, authenticated }) {
    if (!authenticated) {
        return <Navigate to="/login" replace />;
    }

    return children;
}