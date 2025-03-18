using MediatR;
using SistemaHortifruti.Core.Entities;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Commands.CreateFruta
{
    // Arquivo responsável pela lógica de criar uma fruta no BD (banco de dados)
    public class CreateFrutaCommandHandler : IRequestHandler<CreateFrutaCommand, int>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public CreateFrutaCommandHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }
        // Inserindo um novo registro "fruta" no BD (Banco de dados) e retornardo o Id da nova fruta
        public async Task<int> Handle(CreateFrutaCommand request, CancellationToken cancellationToken)
        {
            var fruta = new Fruta(
                request.DescricaoFruta,
                request.ValorA,
                request.ValorB);
            await _context.AddAsync(fruta);
            await _context.SaveChangesAsync();
            return fruta.Id;
        }
    }
}
