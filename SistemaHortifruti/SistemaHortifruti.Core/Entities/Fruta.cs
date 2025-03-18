namespace SistemaHortifruti.Core.Entities
{
    // Modelo da entidade Fruta no banco de dados
    public class Fruta : BaseEntity
    {
        public Fruta(string descricaoFruta, double valorA, double valorB)
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
