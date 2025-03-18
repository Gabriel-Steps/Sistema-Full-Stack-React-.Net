using MediatR;
using SistemaHortifruti.Application.ViewModels;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Queries.GetByIdUsuario
{
    // Arquivo responável por obter o registro tipo "fruta" do BD (BAnco de dados)
    public class GetByIdUsuarioQueryHandler : IRequestHandler<GetByIdUsuarioQuery, UsuarioViewModel>
    {
         // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public GetByIdUsuarioQueryHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }
        // Obtendo o registros"fruta" e retornand os dados do usuário
        public async Task<UsuarioViewModel> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FindAsync(request.Id, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado");
            var usuarioViewModel = new UsuarioViewModel(usuario.Id, usuario.Email, usuario.Senha);
            return usuarioViewModel;

        }
    }
}
