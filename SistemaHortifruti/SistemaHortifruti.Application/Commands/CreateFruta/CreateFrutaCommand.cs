using MediatR;

namespace SistemaHortifruti.Application.Commands.CreateFruta
{
    // Arquivo responsável pelo molde de entrada para criar criar uma fruta no BD (Banco de dados)
    public class CreateFrutaCommand : IRequest<int> // Retorna um int no handler
    {
        public CreateFrutaCommand(string descricaoFruta, double valorA, double valorB)
        {
            DescricaoFruta = descricaoFruta;
            ValorA = valorA;
            ValorB = valorB;
        }

        public string DescricaoFruta { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
    }
}
