using MediatR;
using SistemaHortifruti.Application.ViewModels;

// Arquivo responsável pelo molde de obter um registro "fruta" pelo Id no BD (Banco de dados)
namespace SistemaHortifruti.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioQuery : IRequest<UsuarioViewModel>// Irá retornar os dados do usuário
    {
        public GetByIdUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
