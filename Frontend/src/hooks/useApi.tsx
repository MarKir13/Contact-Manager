const BASE_URL = 'http://localhost:5183/'

const useApi = () => {
    const request = async (endpoint: string, method: 'GET' | 'POST' | 'PUT' | 'DELETE', body?: any) => {
        try {
            const token = sessionStorage.getItem("token");
                    const headers: HeadersInit = {}

                    headers['Content-Type'] = 'application/json'

                    if (token) {
                        headers['Authorization'] = `Bearer ${token}`;
                    }

                    const response = await fetch(`${BASE_URL}${endpoint}`, {method, headers, body: (body ? JSON.stringify(body) : undefined) });

                    if (response.status == 401) {
                        sessionStorage.clear();
                        window.location.href = '/';
                        return {success: false, error: "Sesja wygasła", statusCode: response.status};
                    }

                    let data;
                        try {
                            data = await response.json();
                        } 
                        catch {
                            data = null;
                        }

                        if (response.status === 400 && data?.errors) {
                            return { 
                                success: false, 
                                error: data.title || "Błąd walidacji",
                                statusCode: 400,
                                validationErrors: data.errors
                            };
                        }

                        if (!response.ok) {
                            const errorMessage = data?.title || data?.message || "Wystąpił nieoczekiwany błąd " || response;
                            return { success: false, error: errorMessage, statusCode: response.status };
                        }

                        return { success: true, data };
                    
                    } catch (err) {
                        console.error("API Error:", err);
                        return { success: false, error: "Błąd połączenia z serwerem." };
                    }
                    
                }
};

export default useApi;