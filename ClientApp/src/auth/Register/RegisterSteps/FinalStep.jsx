import styles from "./styles.module.less"
import { useNavigate } from 'react-router-dom';
import { useDispatch } from "react-redux";
import { login } from "../authSlice.js"
import Button from "/src/components/Common/Button/Button.jsx"

export default function FinalStep({ registrationResponse, onPrev }) {
    const userId = "u1fahawa"

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleSuccess = (userId) => {
        dispatch(login({ userId }));
        navigate(`/account/${userId}`);
    };

    const refreshPage = () => {
        window.location.reload();
    }

    return (
        <div className={styles.finalRegisterContainer}>
            <h2>Результат реєстрації</h2>
            {registrationResponse ? (
                registrationResponse.success ? (
                    <div style={{ color: 'green' }}>
                        <h3>{registrationResponse.message}</h3>
                        <Button onClick={handleSuccess(userId)}>В аккаунт</Button>
                    </div>
                ) : (
                    <div style={{ color: 'red' }}>
                        <h3>{registrationResponse.message}</h3>
                        <Button onClick={refreshPage}>Спробувати ще раз</Button>
                    </div>
                )
            ) : (
                <h3>Зачекайте...</h3>
            )}
        </div>
    );
}