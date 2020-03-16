using BelezaNaWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Infrastructure.Data.Mappings
{
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.IdProduct)
                .IsRequired();

            builder.Property(c => c.IdWarehouse)
                .IsRequired();

            builder.Property(c => c.Quantity)
                .IsRequired();

            builder.HasOne(d => d.Product)
                .WithMany(p => p.Inventory)
                .HasForeignKey(d => d.IdProduct);

            builder.HasOne(d => d.Warehouse)
                .WithMany(p => p.Inventory)
                .HasForeignKey(d => d.IdWarehouse);
        }
    }
}
