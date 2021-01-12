using GrupoBoticarioTeste.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoBoticarioTeste.Infrastructure.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder
                .HasKey(p => p.Sku);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(p => p.Warehouses)
                .WithOne(p => p.Product)                      
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
