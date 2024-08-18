import React, { useEffect } from 'react';

function TestApi() {
    useEffect(() => {
        fetch('http://localhost:5000/api/home')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Некоректный ответ сервера!');
                }
                console.log("Сервер работает успешно!")
                return response.json();
            })
            .then(data => console.log(data))
            .catch(error => console.error("Ошибка при получении данных с сервера", error));
    }, []);

    return <div>Проверьте ответ API в вашей консоли.</div>
}

export default TestApi;