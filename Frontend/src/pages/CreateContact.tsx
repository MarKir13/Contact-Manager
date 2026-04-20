import { useEffect, useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";

const CreateContact = () => {
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [password, setPassword] = useState("");
    const [birthDate, setBirthDate] = useState("");

    const [categories, setCategories] = useState([]);
    const [subcategories, setSubcategories] = useState([]);

    const {request} = useApi();

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const response = await request("api/category", "GET");

                if (response.success && response.data)
                {
                    setCategories(response.data.categories);
                }
            } catch (err) {
                alert("Wystąpił nieoczekiwany błąd: " + err);
            }
        }
        
        const fetchSubcategories = async () => {
            try {
                const response = await request("api/subcategory", "GET");

                if (response.success && response.data)
                {
                    setSubcategories(response.data.categories);
                }
            } catch (err) {
                alert("Wystąpił nieoczekiwany błąd: " + err);
            }
        }
        
        fetchCategories();
        fetchSubcategories();
    }, []);

    const handleContactCreation = async () => {

    };

    return (
        <>
            <Navbar />
            <h2>Załóż konto</h2>
            <form onSubmit={handleContactCreation}>
                <div className="inputField">
                    <label>Imię:</label>
                    <input type="text" name="username" value={name} onChange={(e) => setName(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Nazwisko</label>
                    <input type="text" name="surname" value={surname} onChange={(e) => setSurname(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Email:</label>
                    <input type="text" name="email" value={email} onChange={(e) => setEmail(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Numer Telefonu:</label>
                    <input type="text" name="phoneNumber" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Hasło:</label>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                </div>
                <button type="submit">Zaloguj się</button>
            </form>
        </>  
    );
}
 
export default CreateContact;