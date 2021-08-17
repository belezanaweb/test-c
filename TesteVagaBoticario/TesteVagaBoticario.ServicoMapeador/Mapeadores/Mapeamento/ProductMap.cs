using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVagaBoticario.Negocio;

namespace TesteVagaBoticario.ServicoMapeador.Mapeadores.Mapeamento
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(produto => produto.Id)
                .IsRequired();

            builder.Property(produto => produto.Sku)
                .IsRequired();

            builder.Property(produto => produto.Name)
                .IsRequired();

            builder.HasOne(produto => produto.Inventory)
                    .WithOne(inventory => inventory.Product)
                    .HasForeignKey<Inventory>(produto => produto.IdProduct);
        }
    }
}
