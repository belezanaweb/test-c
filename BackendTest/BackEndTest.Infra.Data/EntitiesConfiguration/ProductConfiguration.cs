using BackEndTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndTest.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Sku);
            builder.Property(p => p.Name).HasMaxLength(300).IsRequired();
        }
    }
}
