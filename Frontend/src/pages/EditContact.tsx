import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";

const EditContact = () => {
    const { id } = useParams(); 
    const navigate = useNavigate();
    const { request } = useApi();

    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [category, setCategory] = useState<any | null>(null);
    const [subcategoryId, setSubcategoryId] = useState("");
    const [subcategoryName, setSubcategoryName] = useState("");

    const [categories, setCategories] = useState([]);
    const [subcategories, setSubcategories] = useState([]);

    const today = new Date().toISOString().split("T")[0];
    
    useEffect(() => {
        const fetchExistingContact = async () => {
            try {

                const response = await request(`api/contact/${id}`, "GET");

                if (response.success && response.data) {
                    setName(response.data.contact.name);
                    setSurname(response.data.contact.surname);
                    setEmail(response.data.contact.email);
                    setPhoneNumber(response.data.contact.phoneNumber);
                    setBirthDate(response.data.contact.birthDate);
                    setCategory(response.data.contact.category);
                    setSubcategoryId(response.data.contact.subcategoryId);
                    setSubcategoryName(response.data.contact.subcategoryName);
                } else {
                    alert(response.error);
                }
            } catch (err) {
                alert("Wystapil nieoczekiwany błąd: " + err);
            }
        };

        fetchExistingContact();
    }, []);

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

    const handleUpdate = async (e: any) => {
        e.preventDefault();

        const payload = {
            name: name,
            surname: surname,
            phoneNumber: phoneNumber,
            email: email,
            birthDate: birthDate,
            categoryId: category.id,
            subcategoryId: subcategoryId == "" ? null : subcategoryId,
            subcategoryName: subcategoryName == "" ? null : subcategoryName        
        };

        try {
            const response = await request(`api/contact/${id}`, "PUT", payload);

            if (response.success) {
                alert("Pomyślnie zaktualizowano kontakt!");
                navigate("/");
            } else {
                alert(response.error);
            }
        } catch (err) {
            alert("Wystąpił błąd podczas zapisywania.");
        }
    };

    return (
        <>
            <Navbar />
            <h2>Edytuj kontakt</h2>
            
            <form onSubmit={handleUpdate}>
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
                    <label>Kategoria:</label>
                    <select value={category?.id || ""} onChange={(e) => {
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
};

export default EditContact;