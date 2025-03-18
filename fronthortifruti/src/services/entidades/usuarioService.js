// Arquivo responsável pelos endpoints da entidade Usuário
import api from "../api";

// Procurar o usuário que encaixe nos parâmetros de email e senha
export const loginUsuario = async (email, senha) => {
    try {
        const response = await api.get(`usuarios/login?Email=${email}&Senha=${senha}`);
        alert("Login realizado com sucesso!");
        return response.data.sucesso;
    } catch (e) {
        alert("E-mail ou senha inválidos");
        return false;
    }
    
}

// Criando um usuário e inserindo no BD (Banco de dados)
export const createUsuario = async (email, senha) => {
    try {
        const response = await api.post("usuarios/Create", {
            Email: email,
            Senha: senha
        });
        alert("Usuário cadastrado com sucesso!");
        return response.data;
    } catch (e) {
        alert("Houve um erro ao criar usuário");
    }
}