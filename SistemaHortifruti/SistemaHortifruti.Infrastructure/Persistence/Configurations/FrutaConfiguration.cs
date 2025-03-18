using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaHortifruti.Core.Entities;

// Arquivo responsável pelas configurações da entidade Fruta no BD (Banco de dados)
namespace SistemaHortifruti.Infrastructure.Persistence.Configurations
{
    public class FrutaConfiguration : IEntityTypeConfiguration<Fruta>
    {
        public void Configure(EntityTypeBuilder<Fruta> builder)
        {
            builder.ToTable("Frutas")
                .HasKey(f => f.Id);
            builder.Property(f => f.DescricaoFruta)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(f => f.ValorA)
                .IsRequired();
            builder.Property(f => f.ValorB)
                .IsRequired();
        }
    }
}
