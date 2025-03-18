Sistema Full Stack - React & .NET

📝 Descrição

Este sistema simula um hortifruti, permitindo operações aritméticas entre valores associados ao nome de frutas. Ele permite cadastro e login de usuários, criação de frutas com valores A e B, exclusão de frutas e exibição dos resultados das operações de multiplicação e divisão desses valores.

O backend foi desenvolvido com .NET, utilizando arquitetura limpa, ASP.NET Core, CQRS e alguns princípios SOLID, enquanto o frontend foi construído com React e Vite.

## 🚀 Tecnologias Utilizadas

### 🔹 Backend (.NET)

- .NET Web API

- Entity Framework Core

- SQL Server

- Arquitetura Limpa

- CQRS

- Swagger

- MediatR

- ASP.NET Core

### 🔹 Frontend (JavaScript)

- React.js

- Vite

- React Router

- Axios

- CSS

- JavaScript

## 📌 Pré-requisitos

- Node.js

- Git

- React & Vite

- .NET

## 📌 Etapas de Configuração

### 🔹 Passo 1: Clonar o repositório

```bash
# Clonar o repositório
git clone https://github.com/Gabriel-Steps/Sistema-Full-Stack-React-.Net.git
```

### 🔹 Passo 2: Configurar a conexão com o SQL Server

```bash
# Navegue até o repositório
cd Sistema-Full-Stack-React-.Net/SistemaHortifruti/SistemaHortifruti.API

Localize o arquivo appsettings.json

Encontre a linha abaixo e altere Server e Initial Catalog conforme necessário:

"ConnectionStrings": {
    "ConexaoPadrao": "Server=ServidorOndeVaiHospedar; Initial Catalog=NomeDaDatabase; TrustServerCertificate=True; Integrated Security=True"
}
```

### 🔹 Passo 3: Executar a Migration

```bash
# Acessar a pasta responsável pela criação e conexão com o banco de dados
cd Sistema-Full-Stack-React-.Net/SistemaHortifruti/SistemaHortifruti.Infrastructure

# Criar a Migration

dotnet ef migrations add NomeDaMigration -s ../SistemaHortifruti.API/SistemaHortifruti.API.csproj -o ./Persistence/Migrations

# Aplicar a Migration

dotnet ef database update -s ../SistemaHortifruti.API/SistemaHortifruti.API.csproj
```

### 🔹 Passo 4: Executar a API

```bash
# Acessar a pasta da API
cd Sistema-Full-Stack-React-.Net/SistemaHortifruti/SistemaHortifruti.API

# Iniciar a API
dotnet run
```
### 🔹 Passo 5: Executar o Frontend

```bash
# Acessar a pasta do frontend
cd Sistema-Full-Stack-React-.Net/fronthortifruti

# Iniciar a aplicação
npm run dev
```
Após a execução, o terminal exibirá o servidor local onde o projeto estará rodando.

## 🎥 Vídeo de Apresentação

Fiz um vídeo mostrando o funcionamento da aplicação e o código-fonte. O vídeo foi resumido para não ultrapassar 20 minutos, mas convido vocês a assistirem!

📌 Link do vídeo: Vídeo

