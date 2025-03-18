namespace SistemaHortifruti.Core.Entities
{
    // Modelo da entidade Usuário no banco de dados
    public class Usuario : BaseEntity
    {
        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
