import { login } from "./Redux/authSlice.js";

export default function checkAuthentication(response, dispatch, navigate) {
    if (response.success) {
        handleSuccess("u1fahawa", dispatch, navigate);
    } else {
        refreshPage();
    }
}

function handleSuccess(userId, dispatch, navigate) {
    dispatch(login({ userId }));
    navigate(`/account/${userId}`);
}

function refreshPage() {
    window.location.reload();
}