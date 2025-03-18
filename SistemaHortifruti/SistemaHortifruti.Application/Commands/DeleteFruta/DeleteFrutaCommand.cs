using MediatR;

namespace SistemaHortifruti.Application.Commands.DeleteFruta
{
    // Arquivo responsável pelo molde para deletar um registro fruta do BD (Banco de dados)
    public class DeleteFrutaCommand : IRequest<Unit> // Não irá retornar nenhum dado
    {
        public DeleteFrutaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
