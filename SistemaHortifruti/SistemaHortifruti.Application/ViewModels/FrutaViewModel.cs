namespace SistemaHortifruti.Application.ViewModels
{
    // Arquivo responsável para molde de retorno das informações de um registro tipo "fruta"
    public class FrutaViewModel
    {
        public FrutaViewModel(int id, string descricaoFruta, double valorA, double valorB)
        {
            Id = id;
            DescricaoFruta = descricaoFruta;
            ValorA = valorA;
            ValorB = valorB;
        }

        public int Id { get; set; }
        public string DescricaoFruta { get; set; }
        public double ValorA { get; set; }
        public double ValorB { get; set; }
    }
}
