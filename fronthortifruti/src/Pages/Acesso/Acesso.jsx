import React from 'react'
import './AcessoStyle.css';
import imagemAcesso from '../../assets/imagemHortifruti.png';
import FormAcessar from './FormAcessar/FormAcessar';


export default function Acesso() {
  return (
    <div className='containerAcesso'>
      <div className="containerForm">
        <h1>Seja Bem-Vindo(a)!</h1>
        <FormAcessar tipoAcesso={"Cadastro"}/>
      </div>
      <div className="containerImagem">
        <img src={imagemAcesso} alt="Imagem de frutas" />
      </div>
    </div>
  )
}
