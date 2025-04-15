import React from "react";
import { startGoogleLogin } from "../../api/authenticationApi";

const GoogleAuthenticatedButton = () => {
    const handleGoogleLogin = () => {
        startGoogleLogin();
    }

    return (
        <>
            <div onClick={handleGoogleLogin}>
                <img style={{ width: '40px', height: '40px' }} src="/src/img/sociable/Google.png" alt="Google" />
            </div>
        </>
    );
}

export default GoogleAuthenticatedButton;
