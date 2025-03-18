using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Core.Entities;
using System.Reflection;

// Arquivo responsável pela criação base e conexão com o BD (Banco de dados)
namespace SistemaHortifruti.Infrastructure.Persistence
{
    public class SistemaHortifrutiDbContext : DbContext
    {
        public SistemaHortifrutiDbContext(DbContextOptions<SistemaHortifrutiDbContext> options) : base(options)
        {

        }

        // Criação das entidades no SQL Server
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fruta> Frutas { get; set; }

        // Obtendo as configurações das entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
