using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Application.ViewModels;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Queries.GetAllFrutas
{
    // Arquivo responável por obter todos os registros tipo "fruta" do BD (BAnco de dados)
    public class GetAllFrutasQueryHandler : IRequestHandler<GetAllFrutasQuery, List<FrutaViewModel>>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public GetAllFrutasQueryHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }
        // Obtendo todos os registros "fruta" e transformando em lista
        public async Task<List<FrutaViewModel>> Handle(GetAllFrutasQuery request, CancellationToken cancellationToken)
        {
            return await _context.Frutas
            .Select(f => new FrutaViewModel(
                f.Id,
                f.DescricaoFruta,
                f.ValorA,
                f.ValorB))
            .ToListAsync(cancellationToken);
        }
    }
}
