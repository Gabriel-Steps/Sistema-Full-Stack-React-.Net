using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaHortifruti.Application.Commands.CreateUsuario;
using SistemaHortifruti.Application.Queries.GetByIdUsuario;
using SistemaHortifruti.Application.Queries.GetUsuario;

// Arquivo controller da entidade Usuário
namespace SistemaHortifruti.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Declaração do Imediator
        private readonly IMediator _context;

        public UsuarioController(IMediator context)
        {
            _context = context;
        }

        // Endpoint responsável por obter um usuário pelo Id 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdUsuarioQuery = new GetByIdUsuarioQuery(id);
            var usuario = await _context.Send(getByIdUsuarioQuery);
            return Ok(usuario);
        }

        // Endpoint responsável por criar um novo usuário
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUsuarioCommand createUsuario)
        {
            int id = await _context.Send(createUsuario);
            return CreatedAtAction(nameof(GetById), new { id = id }, createUsuario);
        }

        // Endpoint responsável por procurar um usuário pelo Email e Senha no BD (Banco de dados)
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] GetUsuarioQuery getUsuario)
        {
            var usuario = await _context.Send(getUsuario);
            if (usuario == null)
            {
                return Unauthorized(new { Sucesso = false, Mensagem = "E-mail ou senha inválidos" });
            }
            return Ok(new { Sucesso = true, Mensagem = "Login realizado com sucesso", Usuario = usuario });
        }
    }
}
