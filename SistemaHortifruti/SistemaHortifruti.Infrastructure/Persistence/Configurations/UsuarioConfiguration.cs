using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaHortifruti.Core.Entities;

// Arquivo responsável pelas configurações da entidade Usuário no BD (Banco de dados)
namespace SistemaHortifruti.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios")
                .HasKey(u => u.Id);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
