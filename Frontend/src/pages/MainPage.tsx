import { useEffect, useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";

const MainPage = () => {
    const [contacts, setContacts] = useState([]);

    const {request} = useApi();

    useEffect(() => {
        const fetchContacts = async () => {
            try {
                const response = await request("api/contact", "GET");

                if (response.success && response.data) {
                    setContacts(response.data.contacts);
                } else {
                    alert(response.error);
                }
            } catch (err) {
                alert("Wystąpił nieoczekiwany błąd: " + err);
            }
        };

        fetchContacts();
    },[]);

    return (
        <>
        <Navbar />
        <h2>Lista kontaktów</h2>
        {contacts.map((contact: any) => (
            <div className="contactSummary">
                <h3>{contact.name} {contact.surname}</h3>
                <span>Telefon: {contact.phoneNumber}</span>
                <span>Email: {contact.email}</span>
            </div>
        ))}
        </>
        
    );
}
 
export default MainPage;