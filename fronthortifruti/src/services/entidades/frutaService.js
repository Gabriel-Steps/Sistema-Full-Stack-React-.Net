// Arquivo responsável pelos endpoints da entidade Fruta
import api from "../api";


// Obter todas as frutas do bo BD (Banco de dados)
export const GetAllFrutas = async () => {
    try {
        const response = await api.get("frutas/GetAll");
        return response.data;
    } catch (erro) {
        console.error(`Erro ao buscar frutas da API: ${erro}`);
        return [];
    }
};

// Criando uma fruta e inserindo no BD (Banco de dados)
export const CreateFruta = async (fruta) => {
    try {
        const response = await api.post("frutas/Create", fruta);
        return response.data;
    } catch (erro) {
        console.error(`Erro ao criar fruta: ${erro}`);
        throw erro;
    }
};

export const DeleteFruta = async (id) => {
    try {
        await api.delete(`frutas/Delete/${id}`);
        alert("Fruta deletada com sucesso!");
        window.location.reload();
    } catch (erro) {
        console.log(`Erro ao deletar fruta: ${erro}`);
        alert("Houve um erro ao deletar a fruta! Tente novamente mais tarde");
    }
}