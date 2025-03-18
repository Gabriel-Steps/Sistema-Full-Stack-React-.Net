import React, { useEffect, useState } from 'react';
import './TabelaEFormStyle.css';
import { GetAllFrutas } from '../../../services/entidades/frutaService';
import LinhaTabela from './LinhaTabela/LinhaTabela';
import FormularioConta from './FormularioConta/FormularioConta';

export default function TabelaEForm() {
    const [frutas, setFrutas] = useState([]);
    const [statusAcao, setStatusAcao] = useState("");
    const [descricaoFruta, setDescricaoFruta] = useState("");
    const [valorA, setValorA] = useState(0.00);
    const [valorB, setValorB] = useState(0.00);
    const [formVisivel, setFormVisivel] = useState("invisivel");

    // Itereando a nova fruta na lista das frutas
    const adicionarFrutaNaLista = (novaFruta) => {
        setFrutas((frutas) => [...frutas, novaFruta]); 
    };

    // Recebendo informações da respectiva linha que clicou o botão "Selecionar"
    const receberInformacoesDaLinhaDaTabela = ({descricaoFruta, valorA, valorB}) => {
        setDescricaoFruta(descricaoFruta);
        setValorA(valorA);
        setValorB(valorB);
        setStatusAcao("conta");
        setFormVisivel("visivel");
    }

    // Obtendo as frutas do banco de dados assim que a página inicializa
    useEffect(() => {
        const fetchData = async () => {
            try {
                const dadosFrutas = await GetAllFrutas();
                setFrutas(dadosFrutas);
            } catch (erro) {
                console.error(`Erro ao obter frutas da API: ${erro}`);
            }
        };
        fetchData();
    }, [statusAcao]);

    return (
        <div className='containerTabelaMain'>
            <div className="Tabela">
                <button 
                    className='botaoCriarFruta' 
                    onClick={() => { 
                        setFormVisivel("visivel"); 
                        setStatusAcao("criarFruta");
                    }}
                >Criar fruta
                </button>
                <table>
                    <thead>
                        <tr>
                            <th>Descrição</th>
                            <th>A</th>
                            <th>B</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>
                        {frutas.map((fruta) => (
                            <LinhaTabela 
                                key={fruta.id} 
                                descricaoFruta={fruta.descricaoFruta} 
                                valorA={fruta.valorA} 
                                valorB={fruta.valorB} 
                                id={fruta.id}
                                receberInfo={receberInformacoesDaLinhaDaTabela} 
                            />
                        ))}
                    </tbody>
                </table>
            </div>
            <FormularioConta 
                descricaoFruta={descricaoFruta} 
                valorA={valorA} 
                valorB={valorB} 
                visivel={formVisivel} 
                statusAcao={statusAcao} 
                adicionarFruta={adicionarFrutaNaLista} 
            />
        </div>
    );
}
