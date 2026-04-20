import { NavLink } from "react-router-dom";

const Navbar = () => {

    const token = sessionStorage.getItem("token");
    const isAuthorized = token ? true : false;

    if (isAuthorized) {
        return (
            <nav>
                <h1>Witaj w menedżerze kontaktów</h1>
                <NavLink to="/login">Wyloguj się</NavLink>
                <NavLink to="/add">Dodaj kontakt</NavLink>
            </nav>
        );
    } else {
        return (
            <nav>
                <h1>Witaj w menedżerze kontaktów</h1>
                <NavLink to="/register">Zarejestruj się</NavLink>
                <NavLink to="/login">Zaloguj się</NavLink>
            </nav>
        );
    }
    
}
 
export default Navbar;
