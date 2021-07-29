using BWEBTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWEBTestBack.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Sku)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.IsMarketable)
                .IsRequired()
                .HasDefaultValue(false);

            // 1 : 1 => Product : Inventory
            builder.HasOne(p => p.Inventory)
                .WithOne(i => i.Product);

            builder.ToTable("Products");
        }
    }
}
