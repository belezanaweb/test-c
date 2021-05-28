using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Database.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Core.Inventory>
    {
        public void Configure(EntityTypeBuilder<Core.Inventory> builder)
        {
            builder.HasKey(p => p.Sku);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Sku);
            builder.HasOne(p => p.Product).WithOne(p => p.Inventory).HasForeignKey<Core.Inventory>(p => p.Sku).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
