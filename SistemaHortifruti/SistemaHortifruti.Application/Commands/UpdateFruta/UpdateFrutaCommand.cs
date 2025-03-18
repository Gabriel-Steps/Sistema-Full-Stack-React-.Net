using MediatR;
using System.Text.Json.Serialization;

namespace SistemaHortifruti.Application.Commands.UpdateFruta
{
    // // Arquivo responsável pelo molde para atualizar um registro fruta do BD (Banco de dados)
    public class UpdateFrutaCommand : IRequest<Unit> // Não irá retornar nenhum valor
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string DescricaoFruta { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
    }
}
