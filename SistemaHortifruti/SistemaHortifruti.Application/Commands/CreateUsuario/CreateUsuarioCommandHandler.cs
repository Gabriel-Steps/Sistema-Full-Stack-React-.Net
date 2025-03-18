using MediatR;
using SistemaHortifruti.Core.Entities;
using SistemaHortifruti.Infrastructure.Persistence;

namespace SistemaHortifruti.Application.Commands.CreateUsuario
{
    // Arquivo responsável pela lógica de criar um usuário no BD (banco de dados)
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        // Declaração do dbContext (conexão com a database)
        private readonly SistemaHortifrutiDbContext _context;
        public CreateUsuarioCommandHandler(SistemaHortifrutiDbContext context)
        {
            _context = context;
        }

        // Inserindo um novo registro "usuário" no BD (Banco de dados) e retornardo o Id do novo usuário
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(
                request.Email,
                request.Senha);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync(cancellationToken);
            return usuario.Id;
        }
    }
}
