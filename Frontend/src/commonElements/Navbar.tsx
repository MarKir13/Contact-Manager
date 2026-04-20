import { NavLink } from "react-router-dom";

const Navbar = () => {
    return (
        <nav>
            <h1>Witaj w menedżerze kontaktów</h1>
            <NavLink to="/register">Zarejestruj się</NavLink>
            <NavLink to="/login">Zaloguj się</NavLink>
        </nav>
    );
}
 
export default Navbar;
