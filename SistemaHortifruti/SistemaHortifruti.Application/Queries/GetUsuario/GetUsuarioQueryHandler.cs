using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Application.ViewModels;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Queries.GetUsuario
{
    // Arquivo responável por obter o usuário do BD (BAnco de dados)
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, UsuarioViewModel>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public GetUsuarioQueryHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }

        // Obtendo o registro tipo "usuário" pelo Email e Senha e transformando em lista
        public async Task<UsuarioViewModel?> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email && u.Senha == request.Senha);
            if (usuario == null)
            {
                return null;
            }
            var usuarioViewModel = new UsuarioViewModel(usuario.Id, usuario.Email, usuario.Senha);
            return usuarioViewModel;

        }
    }
}
