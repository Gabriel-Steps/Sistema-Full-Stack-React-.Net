import axios from "axios";

// Conexão com a API do .Net
const api = axios.create({
    baseURL: "http://localhost:5279/api"
});

export default api;