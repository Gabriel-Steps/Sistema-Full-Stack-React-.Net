using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaHortifruti.Application.Commands.CreateFruta;
using SistemaHortifruti.Application.Commands.DeleteFruta;
using SistemaHortifruti.Application.Commands.UpdateFruta;
using SistemaHortifruti.Application.Queries.GetAllFrutas;

// Arquivo controller da entidade Fruta
namespace SistemaHortifruti.API.Controllers
{
    [Route("api/frutas")]
    [ApiController]
    public class FrutaController : ControllerBase
    {
        // Declaração do Imediator
        private readonly IMediator _context;
        public FrutaController(IMediator context) 
        {
            _context = context;
        }

        // Endpoint responsável por obter todas as frutas dentro do BD (Banco de dados)
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getAllFrutasQuery = new GetAllFrutasQuery();
            var frutas = await _context.Send(getAllFrutasQuery);
            if(frutas.Count == 0)
            {
                return NoContent();
            }
            return Ok(frutas);
        }

        // Endpoint responsável por criar uma nova fruta 
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateFrutaCommand newFruta)
        {
            int id = await _context.Send(newFruta);
            return Ok(id);
        }

        // Endpoint responsável por atualizar dados de uma fruta do BD (Banco de dados)
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFrutaCommand inputModel)
        {
            inputModel.Id = id;
            await _context.Send(inputModel);
            return Ok();
        }

        // Endpoint responsável por deletar uma fruta do BD (Banco de dados)
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFrutaCommand(id);
            await _context.Send(command);
            return Ok();
        }
    }
}
