using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Infra.Data.EntityConfig
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            
            builder.HasKey(p => p.ProdutoId);

            builder.Property(p => p.Nome).HasMaxLength(200);
            builder.Ignore(p => p.Inventario);

            builder.Ignore(p => p.Validacao);
        }
    }
}
