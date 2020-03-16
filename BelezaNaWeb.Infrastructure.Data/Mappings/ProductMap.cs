using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BelezaNaWeb.Domain.Models;

namespace BelezaNaWeb.Infrastructure.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Sku)
                .IsRequired();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.HasMany(d => d.Inventory)
                .WithOne(p => p.Product)
                .HasForeignKey(d => d.IdProduct);
        }
    }
}
