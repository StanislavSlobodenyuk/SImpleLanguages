import React from "react";
import { startGoogleLogin } from "../../api/authenticationApi";

const GoogleAuthenticatedButton = () => {
    const handleGoogleLogin = () => {
        startGoogleLogin();
    }

    return (
        <button onClick={handleGoogleLogin}>Google</button>
    );
}

export default GoogleAuthenticatedButton;
