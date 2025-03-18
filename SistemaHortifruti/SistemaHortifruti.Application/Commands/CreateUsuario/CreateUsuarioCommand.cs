using MediatR;

namespace SistemaHortifruti.Application.Commands.CreateUsuario
{
    // Arquivo responsável pelo molde de entrada para criar criar um usuário no BD (Banco de dados)
    public class CreateUsuarioCommand : IRequest<int> // Retorna um int no handler
    {
        public CreateUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
