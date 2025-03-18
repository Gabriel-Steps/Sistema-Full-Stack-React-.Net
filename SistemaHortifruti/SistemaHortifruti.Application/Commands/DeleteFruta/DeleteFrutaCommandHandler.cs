using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Commands.DeleteFruta
{
    // Arquivo responsável pela lógica de deletar um registro "fruta" no BD (banco de dados)
    public class DeleteFrutaCommandHandler : IRequestHandler<DeleteFrutaCommand, Unit>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public DeleteFrutaCommandHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }
        // Deletando um registro "fruta" no BD (Banco de dados)
        public async Task<Unit> Handle(DeleteFrutaCommand request, CancellationToken cancellationToken)
        {
            var fruta = await _context.Frutas.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken)
                ?? throw new KeyNotFoundException("Fruta não encontrada");

            _context.Frutas.Remove(fruta);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
