namespace SistemaHortifruti.Application.ViewModels
{
    // Arquivo responsável para molde de retorno das informações de um registro tipo "usuário"
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string email, string senha)
        {
            Id = id;
            Email = email;
            Senha = senha;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
