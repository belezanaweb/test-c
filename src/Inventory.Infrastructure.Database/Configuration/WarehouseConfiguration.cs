using Inventory.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Database.Configuration
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Core.Warehouse> builder)
        {
            builder.HasKey(p => new { p.Sku, p.Locality, p.Type });
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Locality);
            builder.Property(p => p.Type);
            builder.HasOne(p => p.Inventory).WithMany(p => p.Warehouses).HasForeignKey(p => p.Sku).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
