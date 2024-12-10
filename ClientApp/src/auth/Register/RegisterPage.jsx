import { useState } from "react";
import { sendRegistrationData } from "/src/api/AuthenticationApi/authenticationApi.js";
import FirstStep from './RegisterSteps/FirstStep.jsx';
import SecondStep from './RegisterSteps/SecondStep.jsx';
import ThirdStep from './RegisterSteps/ThirdStep.jsx';
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import checkAuthentication from '../checkAuthentication.jsx';

export default function RegisterPage() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [currentStep, setCurrentStep] = useState(1)
    const [formData, setFormData] = useState({
        userName: "",
        password: '',
        confirmedPassword: '',
        email: '',
        nativeLanguage: '',
        learningLanguage: '',
        learningLevel: '',
        studySchedule: { time: '', days: [] }
    })

    const handlePrev = () => setCurrentStep((prev => prev - 1))
    const handleNext = () => { setCurrentStep(prev => prev + 1) }

    const handleCharge = (key, value) => {
        setFormData((prev) => ({ ...prev, [key]: value }))
    }

    const sendData = async () => {
        var responseData = {}
        try {
            const response = await sendRegistrationData(formData);
            responseData = { success: true, message: "Реєстрація успішна!" };
        } catch (error) {
            responseData = { success: false, message: "Помилка при реєстрації!" };
        }

        checkAuthentication(responseData, dispatch, navigate);
    };

    return (
        <div className="content-container">
            {currentStep === 1 && (
                <FirstStep formData={formData} onChange={handleCharge} onNext={handleNext} />
            )}
            {currentStep === 2 && (
                <SecondStep formData={formData} onChange={handleCharge} onNext={handleNext} onPrev={handlePrev} />
            )}
            {currentStep === 3 && (
                <ThirdStep formData={formData} onChange={handleCharge} onNext={handleNext} onPrev={handlePrev} sendData={sendData} />
            )}
        </div>
    );
}