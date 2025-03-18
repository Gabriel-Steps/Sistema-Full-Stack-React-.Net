using MediatR;
using SistemaHortifruti.Application.ViewModels;

// Arquivo responsável pelo molde de obter todos os registros "fruta" no BD (Banco de dados)
namespace SistemaHortifruti.Application.Queries.GetAllFrutas
{
    public class GetAllFrutasQuery : IRequest<List<FrutaViewModel>> // Irá retornar uma lista de registro "frutas"
    {

    }
}
