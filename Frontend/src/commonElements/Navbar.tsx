import { NavLink } from "react-router-dom";

const Navbar = () => {

    const token = sessionStorage.getItem("token");
    const isAuthorized = token ? true : false;

    const handleLogout = () => {
        sessionStorage.removeItem("token");
        window.location.href = "/";
    }

    return (
        <nav>
            <h1>Witaj w menedżerze kontaktów</h1>
            
            {isAuthorized ? (
                <>
                    <NavLink className="navButton" to="/add">Dodaj kontakt</NavLink>
                    <button className="navButton" onClick={handleLogout}>Wyloguj się</button>
                </>
            ) : (
                <>
                    <NavLink className="navButton" to="/register">Zarejestruj się</NavLink>
                    <NavLink className="navButton" to="/login">Zaloguj się</NavLink>
                </>
            )}
        </nav>
    );
    
}
 
export default Navbar;
