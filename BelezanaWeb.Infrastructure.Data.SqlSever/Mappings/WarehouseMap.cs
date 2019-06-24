using BelezanaWeb.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezanaWeb.Infrastructure.Data.SqlSever.Mappings
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse");

            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Locality).HasColumnName("Locality");
            builder.Property(c => c.Quantity).HasColumnName("Quantity");
            builder.Property(c => c.Type).HasColumnName("Type");
            builder.Property(c => c.Created).HasColumnName("Created");
            builder.Property(c => c.Updated).HasColumnName("Updated");
            builder.Property(c => c.Active).HasColumnName("Active");

            builder.Property(p => p.ProductId)
            .IsRequired()
            .HasColumnType("bigint")
            .HasColumnName("ProductId");

            builder.HasOne(p => p.Product).WithMany(p => p.Warehouses).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

