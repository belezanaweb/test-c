using Boticario.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.Infra.Data.Mappings
{
    public class Produto_Configuration : IEntityTypeConfiguration<TabelaProduto>
    {
        public void Configure(EntityTypeBuilder<TabelaProduto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(nameof(TabelaProduto.Id));

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany(x => x.TabelaEstoque).WithOne(x => x.Produto).HasForeignKey(x => x.ProdutoId);
        }
    }
}
