import { jwtDecode } from "jwt-decode";

export function decodeToken(token) {
    try {
        if (!token || typeof token !== "string") {
            throw new Error("Invalid token: not a string");
        }
        const decode = jwtDecode(token)
        return decode;
    } catch (error) {
        console.error("Failed to decode token:", error);
        return null;
    }
}
