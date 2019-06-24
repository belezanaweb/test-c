using BelezanaWeb.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezanaWeb.Infrastructure.Data.SqlSever.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Sku).HasColumnName("Sku");
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.Created).HasColumnName("Created");
            builder.Property(c => c.Updated).HasColumnName("Updated");
            builder.Property(c => c.Active).HasColumnName("Active");
        }
    }
}

