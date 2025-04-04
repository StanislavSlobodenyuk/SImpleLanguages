import axios from "axios";

export const sendRegistrationData = async (formData) => {
    try {
        const response = await axios.post("http://localhost:5000/api/Register", formData);
        console.log("Реєстрація успішна:", response.data);
        return response.data;
    } catch (error) {
        console.error('Помилка при відправці даних:', error);
        throw error;
    }
};

export const sendLoginData = async (formData) => {
    try {
        const response = await axios.post("http://localhost:5000/api/Authorization/Login", formData);
        console.log("Виконано вхід в аккаунт:", response.data)
        return response.data;
    } catch (error) {
        console.error('Помилка при відправці даних:', error);
        throw error;
    }
};