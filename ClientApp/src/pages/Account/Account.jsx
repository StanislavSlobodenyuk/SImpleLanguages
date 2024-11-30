import React from 'react';
import { useDispatch } from 'react-redux';
import { logout } from '/src/auth/Register/authSlice.js';
import { useNavigate } from 'react-router-dom';
export default function Account() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const handleLogout = () => {
        dispatch(logout());
        navigate('/login');
    }

    return (
        <>
            <h1>Ваш аккаунт</h1>
            <button onClick={handleLogout}>Выйти</button>
        </>
    )
}