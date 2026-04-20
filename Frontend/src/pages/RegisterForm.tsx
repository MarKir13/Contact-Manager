import { useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";
import { useNavigate } from "react-router-dom";

const RegisterForm = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [repeatPassword, setRepeatPassword] = useState("");

    const { request } = useApi();
    const navigate = useNavigate();

    const handleRegister = async (e: any) => {
        e.preventDefault();
        try {
            if ( password != repeatPassword ) {
                alert("Hasła muszą być takie same!");
                return false;
            }

            const payload = {
                username: username,
                password: password
            };
            
            const response = await request("api/user/register", "POST", payload);

            if( response.success )
            {
                navigate("/login");
            } else {
                if (response.validationErrors && Object.keys(response.validationErrors).length > 0) {
                    
                    const firstValidationError = Object.values(response.validationErrors)[0][0];
                    
                    alert(firstValidationError);
                } else {
                    alert("Błąd: " + response.error);
                }
            }

        } catch (err) {
            alert("Wystąpił nieoczekiwany błąd: " + err);
        }
        
    }

    return (
        <>
            <Navbar />
            <h2>Załóż konto</h2>
            <form onSubmit={handleRegister}>
                <div className="inputField">
                    <label>Nazwa użytkownika:</label>
                    <input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Hasło:</label>
                    <input type="password" name="password" onChange={(e) => setPassword(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Powtórz hasło:</label>
                    <input type="password" onChange={(e) => setRepeatPassword(e.target.value)}/>
                </div>
                <button type="submit">Załóż konto</button>
            </form>
        </>
    );
}
 
export default RegisterForm;