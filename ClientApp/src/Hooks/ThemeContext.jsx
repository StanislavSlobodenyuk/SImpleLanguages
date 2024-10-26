
import React, { createContext, useContext, useState } from 'react';

const ThemeContext = createContext();

// Компонент-провайдер темы
export const ThemeProvider = ({ children }) => {
    const [theme, setTheme] = useState(() => {
        return localStorage.getItem('Theme') || 'light';
    });


    const changeTheme = () => {
        setTheme(prevTheme => {
            const newTheme = prevTheme === 'dark' ? 'light' : 'dark'

            localStorage.setItem('Theme', newTheme)
            return newTheme
        });
    };

    return (
        <ThemeContext.Provider value={{ theme, changeTheme }}>
            {children}
        </ThemeContext.Provider>
    );
};

// Хук для использования контекста
export const useTheme = () => {
    return useContext(ThemeContext);
};
