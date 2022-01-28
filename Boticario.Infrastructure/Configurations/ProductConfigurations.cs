using Boticario.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.Infrastructure.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder
                .HasOne(product => product.Inventory)
                .WithMany()
                .HasForeignKey(product => product.IdInventory)
                .OnDelete(DeleteBehavior.Restrict);                
        }
    }
}
