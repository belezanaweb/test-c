using Boticario.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.Infra.Data.Mappings
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<TabelaEstoque>
    {
        public void Configure(EntityTypeBuilder<TabelaEstoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(nameof(TabelaEstoque.Id));

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId);
        }
    }
}
