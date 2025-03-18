import React from 'react'
import './FormAcessar.css';
import { useState} from 'react'
import { createUsuario, loginUsuario } from '../../../services/entidades/usuarioService';
import { useNavigate } from 'react-router-dom';

export default function FormAcessar() {
  const [tipoAcesso, setTipoAcesso] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const navigate = useNavigate();
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      // Verificar se o acesso é pelo login
      if (tipoAcesso == "Login") {
        const resposta = await loginUsuario(email, senha);
        if (resposta) {
          navigate("/home");
        }
      }
      // Verificar se o acesso é pelo cadastro
      if (tipoAcesso == "Cadastro") {
        const resposta = await createUsuario(email, senha);
        if (resposta) {
          navigate("/home");
        }
      }
    } catch (e) {
      alert(`Houve um erro interno: ${e}`);
    }
  }
  return (
      <form className='formAcesso' onSubmit={handleSubmit}>
          <label htmlFor="email">E-mail</label>
          <input type="email" name="email" onChange={(e) => setEmail(e.target.value)} id="email" placeholder='Digite o seu e-mail' required/>
          <label htmlFor="senha">Senha</label>
          <input type="password" name="senha" onChange={(e) => setSenha(e.target.value)} id="senha" placeholder='Digite a sua senha' maxLength={30} required/>
          <div className="containerButtonsForm">
              <button onClick={() => setTipoAcesso("Login")}>Login</button>
              <button onClick={() => setTipoAcesso("Cadastro")}>Cadastre-se</button>
          </div>
        </form>
  )
}
