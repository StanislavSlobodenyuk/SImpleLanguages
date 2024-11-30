import { useState } from "react";
import { sendRegistrationData } from "../Api/authenticationApi.js";
import { FirstStep, SecondStep, ThirdStep, FinalStep } from './RegisterSteps/Steps.js'

export default function RegisterPage() {
    const [currentStep, setCurrentStep] = useState(1)
    const [registrationResponse, setRegistrationResponse] = useState(null);
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
        try {
            const response = await sendRegistrationData(formData);
            setRegistrationResponse({ success: true, message: "Реєстрація успішна!" });
        } catch (error) {
            setRegistrationResponse({ success: false, message: "Помилка при реєстрації!" });
        }
    };

    return (
        <div>
            {currentStep === 1 && (
                <FirstStep formData={formData} onChange={handleCharge} onNext={handleNext} />
            )}
            {currentStep === 2 && (
                <SecondStep formData={formData} onChange={handleCharge} onNext={handleNext} onPrev={handlePrev} />
            )}
            {currentStep === 3 && (
                <ThirdStep formData={formData} onChange={handleCharge} onNext={handleNext} onPrev={handlePrev} sendData={sendData} />
            )}
            {currentStep === 4 && (
                <FinalStep registrationResponse={registrationResponse} onPrev={handlePrev} />
            )}
        </div>
    );
}