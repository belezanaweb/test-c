using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWebApplication.Persistence.EntityConfigurations
{
    internal class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable(nameof(Inventory));

            builder.HasKey(o => o.Id);

            builder.HasMany<Warehouse>(x => x.Warehouses)
                .WithOne(x => x.Inventory)
                .HasForeignKey(x => x.InventoryId);

            builder.HasOne<Product>(x => x.Product)
                   .WithOne(x => x.Inventory)
                   .HasForeignKey<Inventory>(x => x.ProductId);
        }
    }
}