using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Commands.UpdateFruta
{
     // Arquivo responsável pela lógica de atualizar um registro "fruta" no BD (banco de dados)
    public class UpdateFrutaCommandHandler : IRequestHandler<UpdateFrutaCommand, Unit>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public UpdateFrutaCommandHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }
        // Atualizando um registro "fruta" no BD (Banco de dados)
        public async Task<Unit> Handle(UpdateFrutaCommand request, CancellationToken cancellationToken)
        {
            var fruta = await _context.Frutas.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken)
                ?? throw new Exception("Fruta não encontrada");
            fruta.DescricaoFruta = request.DescricaoFruta;
            fruta.ValorA = request.ValorA;
            fruta.ValorB = request.ValorB;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
