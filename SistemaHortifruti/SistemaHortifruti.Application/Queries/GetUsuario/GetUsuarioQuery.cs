using MediatR;
using SistemaHortifruti.Application.ViewModels;

// Arquivo responsável pelo molde de obter o usuário pelo Email e Senha no BD (Banco de dados)
namespace SistemaHortifruti.Application.Queries.GetUsuario
{
    public class GetUsuarioQuery : IRequest<UsuarioViewModel> // Irá retornar os dados do usuário
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
