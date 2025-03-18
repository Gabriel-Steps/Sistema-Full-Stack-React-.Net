import React, { useState } from 'react'
import { DeleteFruta } from '../../../../services/entidades/frutaService';

export default function LinhaTabela({ descricaoFruta, valorA, valorB, receberInfo, id }) {
  const [tipoAcao, setTipoAcao] = useState("leitura");
    const handleEnviar = () => {
        receberInfo({descricaoFruta, valorA, valorB});
    }
  const handleDeletar = () => {
    try {
      DeleteFruta(id);
    } catch (erro) {
      console.error(`Erro ao deletar a fruta!\n${erro}`)
    }
  }
  return (
    <tr>
        <td>{descricaoFruta}</td>
        <td>{valorA}</td>
        <td>{valorB}</td>
        <td>
          <button onClick={handleEnviar}>Selecionar</button>
          <button className='buttonDeleteFruta' onClick={() => handleDeletar(id)}>Deletar</button>
        </td>
    </tr>
  )
}
