using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Infra.Data.EntityConfig
{
    public class InventarioConfig : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventarios");

            builder.HasKey(p => p.InventarioId);

            builder.Property(p => p.Localidade).HasMaxLength(200);
            builder.Property(p => p.Tipo).HasMaxLength(200);

            builder.Ignore(p => p.Validacao);
        }
    }
}
