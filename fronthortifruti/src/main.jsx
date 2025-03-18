import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './index.css'
import Acesso from './Pages/Acesso/Acesso.jsx'
import Home from './Pages/Home/Home.jsx'

// Arquivo responsável pelas rotas e páginas do sistema
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Router>
      <Routes>
        <Route path='/' element={<Acesso />} />
        <Route path='/home' element={<Home />} />
      </Routes>
    </Router>
  </StrictMode>
)
