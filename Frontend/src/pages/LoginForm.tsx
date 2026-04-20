import { useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";
import { useNavigate } from "react-router-dom";

const LoginForm = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const {request} = useApi();
    const navigate = useNavigate();

    const handleLogin = async (e: any) => {
        e.preventDefault()
        
        try {
            const payload = {
                username: username,
                password: password
            };

            const response = await request("api/user/login", "POST", payload);

            if (response.success && response.data) {
                sessionStorage.setItem("token", response.data.token);
                alert("Pomyslnie zalogowano");
                navigate("/");
            }
        } catch(err) {
            alert("Wystąpił nieoczekiwany błąd: " + err);
        }
    };

    return ( 
        <>
            <Navbar />
            <h2>Załóż konto</h2>
            <form onSubmit={handleLogin}>
                <div className="inputField">
                    <label>Nazwa użytkownika:</label>
                    <input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Hasło:</label>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                </div>
                <button type="submit">Załóż konto</button>
            </form>
        </>  
    );
}
 
export default LoginForm;