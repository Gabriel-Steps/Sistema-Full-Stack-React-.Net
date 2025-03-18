import React, { useState } from 'react';
import './FormularioContaStyle.css';
import { CreateFruta } from '../../../../services/entidades/frutaService';

export default function FormularioConta(props) {
    const [resultado, setResultado] = useState("");
    const [descricaoFruta, setDescricaoFruta] = useState("");
    const [valorA, setValorA] = useState(0.00);
    const [valorB, setValorB] = useState(0.00);

    const handleSubmit = async () => {
        // Criação do objeto Fruta para realizar o post
        const novaFruta = { descricaoFruta, valorA: parseFloat(valorA), valorB: parseFloat(valorB)};
        try {
            // Obter retorno da api do método post
            const frutaCriada = await CreateFruta(novaFruta);
            if (props.adicionarFruta) {
                props.adicionarFruta(frutaCriada);
            }
            setDescricaoFruta("");
            setValorA(0.00);
            setValorB(0.00);
        } catch (erro) {
            console.error(`Erro ao criar fruta: ${erro}`);
        }
    };
    // Form para realizar a conta de multiplicação e divisão
    if (props.statusAcao === "conta") {
        return (
            <div className={`containerFormDescricaoFruta ${props.visivel}`}>
                <label>Descrição</label>
                <input type="text" value={props.descricaoFruta} disabled />
                <label>Valor A</label>
                <input type="text" value={props.valorA} disabled />
                <label>Valor B</label>
                <input type="text" value={props.valorB} disabled />
                <label>Resultado</label>
                <input type="text" disabled value={resultado} />
                <div className="containerButtonConta">
                    <button onClick={() => setResultado(props.valorA == 0 || props.valorB == 0 ?
                        "Não pode dividir um número por zero" : 
                        (props.valorA / props.valorB).toString()
                    )}>Dividir</button>
                    <button onClick={() => setResultado((props.valorA * props.valorB).toString())}>Multiplicar</button>
                </div>
            </div>
        );
    }
    // Form para realizar a criação de da fruta
    if (props.statusAcao === "criarFruta") {
        return (
            <div className={`containerFormDescricaoFrutaCriar ${props.visivel}`}>
                <form onSubmit={handleSubmit}>
                    <label>Descrição</label>
                    <input 
                        type="text" 
                        placeholder="Digite o nome da fruta" 
                        value={descricaoFruta}
                        onChange={(e) => setDescricaoFruta(e.target.value)}
                    />
                    <label>Valor A</label>
                    <input 
                        type="number" 
                        placeholder="Digite o valor A" 
                        value={valorA}
                        onChange={(e) => setValorA(e.target.value)}
                    />
                    <label>Valor B</label>
                    <input 
                        type="number" 
                        placeholder="Digite o valor B" 
                        value={valorB}
                        onChange={(e) => setValorB(e.target.value)}
                    />
                    <div className="containerButtonConta">
                        <button type="submit">Enviar</button>
                    </div>
                </form>
            </div>
        );
    }
}
