using Inventory.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Database.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Sku);
            builder.Property(p => p.Sku);
            builder.Property(p => p.Name);
            builder.Property(p => p.IsMarketable);

            builder.HasOne(p => p.Inventory).WithOne(p => p.Product).HasForeignKey<Core.Inventory>(p => p.Sku).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
