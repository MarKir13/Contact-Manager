import { useEffect, useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";
import { useNavigate } from "react-router-dom";

const CreateContact = () => {
    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [password, setPassword] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [category, setCategory] = useState<any | null>(null);
    const [subcategoryId, setSubcategoryId] = useState("");
    const [subcategoryName, setSubcategoryName] = useState("");

    const [categories, setCategories] = useState([]);
    const [subcategories, setSubcategories] = useState([]);

    const today = new Date().toISOString().split("T")[0];

    const {request} = useApi();
    const navigate = useNavigate();

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
                    setSubcategories(response.data.subcategories);
                }
            } catch (err) {
                alert("Wystąpił nieoczekiwany błąd: " + err);
            }
        }
        
        fetchCategories();
        fetchSubcategories();
    }, []);

    const handleContactCreation = async (e: any) => {
        e.preventDefault();

        if (category == null) {
            alert("Kategoria nie może być pusta!");
            return;
        }

        try {
            const payload = {
                name: name,
                surname: surname,
                phoneNumber: phoneNumber,
                email: email,
                password: password,
                birthDate: birthDate,
                categoryId: category.id,
                subcategoryId: subcategoryId == "" ? null : subcategoryId,
                subcategoryName: subcategoryName == "" ? null : subcategoryName
            };

            const response = await request("api/contact", "POST", payload);

            if (response.success) {
                alert("Pomyslnie dodano nowy kontak!");
                navigate("/");
            } else {
                if (response.validationErrors && Object.keys(response.validationErrors).length > 0) {
                    
                    const firstValidationError = Object.values(response.validationErrors)[0][0];
                    if(firstValidationError == "The dto field is required.") {
                        alert("Jedno z wymaganych pól jest puste");
                    } else {
                        alert(firstValidationError);
                    }
                } else {
                    alert("Błąd: " + response.error);
                }
            }

        } catch (err) {
            alert("Wystąpił nieoczekiwany błąd: " + err);
        }
    };

    return (
        <>
            <Navbar />
            <h2>Dodaj kontakt</h2>
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
                    <label>Data urodzenia:</label>
                    <input type="date" name="birthDate" max={today} value={birthDate} onChange={(e) => setBirthDate(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Hasło:</label>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                </div>
                <div className="inputField">
                    <label>Kategoria:</label>
                    <select onChange={(e) => {
                        const selectedId = e.target.value;
                        const selectedCat = categories.find((c: any) => c.id === selectedId);
                        setCategory(selectedCat || null);
                        setSubcategoryId("");
                        setSubcategoryName("");
                    }}>
                        <option value="">Wybierz kategorię</option>
                        {categories.map((category: any) => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
                </div>

                {category?.name === "Służbowy" && (
                    <div className="inputField">
                        <label>Podkategoria:</label>
                        <select value={subcategoryId} onChange={(e) => setSubcategoryId(e.target.value)}>
                            <option value="">Wybierz podkategorię</option>
                            {subcategories.map((sub: any) => (
                                <option key={sub.id} value={sub.id}>
                                    {sub.name}
                                </option>
                            ))}
                        </select>
                    </div>
                )}

                {category?.name === "Inny" && (
                    <div className="inputField">
                        <label>Podkategoria:</label>
                        <input 
                            type="text" 
                            value={subcategoryName} 
                            onChange={(e) => setSubcategoryName(e.target.value)}
                        />
                    </div>
                )}

                <button type="submit">Dodaj kontakt</button>
            </form>
        </>  
    );
}
 
export default CreateContact;