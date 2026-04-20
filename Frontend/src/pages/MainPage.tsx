import { useEffect, useState } from "react";
import Navbar from "../commonElements/Navbar";
import useApi from "../hooks/useApi";

const MainPage = () => {
    const [contacts, setContacts] = useState([]);
    const [contactDetails, setContactDetails] = useState<any | null>(null);

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
    },[contactDetails]);

    const fetchDetails = async (id: string) => {
        try {
            const response = await request(`api/contact/${id}`, "GET");

            if ( response.success && response.data) {
                setContactDetails(response.data.contact);
            } else {
                alert(response.error);
            }
        } catch (err) {
            alert("Wystąpił nieoczekiwany błąd: " + err);
        }
    }

    const handleDeletion = async (id: string) => {


        try {
            const response = await request(`api/contact/${id}`, "DELETE");

            if ( response.success ) {
                alert("Pomyslnie usunieto kontakt");
                setContactDetails(null);
            } else {
                alert(response.error);
            }
        } catch (err) {
            alert("Wystąpił nieoczekiwany błąd: " + err);
        }
    }

    return (
        <>
        <Navbar />
        <h2>Lista kontaktów</h2>
        {contacts.map((contact: any) => (
            <div className="contactSummary">
                <h3>{contact.name} {contact.surname}</h3>
                <span>Telefon: {contact.phoneNumber}</span>
                <span>Email: {contact.email}</span>
                <button onClick={() => fetchDetails(contact.id)}>Szczegóły</button>
            </div>
        ))}

        {contactDetails && (
            <div className="modalOverlay">
                <div className="modalContent">
                    <h2>Szczegóły kontaktu</h2>
                    <span>Imię i nazwisko: {contactDetails.name} {contactDetails.surname}</span>
                    <span>Email: {contactDetails.email}</span>
                    <span>Telefon: {contactDetails.phoneNumber}</span>
                    <span>Data urodzenia: {contactDetails.birthDate}</span>
                    <span>Kategoria: {contactDetails.categoryName}</span>
                    {contactDetails.subcategoryName && ( <span>Podkategoria: {contactDetails.subcategoryName}</span> )}
                    
                    <button onClick={() => setContactDetails(null)}>Zamknij</button>
                    <button onClick={() => handleDeletion(contactDetails.id)}>Usuń kontakt</button>
                </div>
            </div>
        )}
        </>
    );
}
 
export default MainPage;