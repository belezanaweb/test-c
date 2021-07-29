using BWEBTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWEBTestBack.Data.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Quantity)
                .IsRequired();


            // 1 : N => Inventory : Warehouses
            builder.HasMany(i => i.Warehouses)
                .WithOne(w => w.Inventory)
                .HasForeignKey(w => w.InventoryId);

            builder.ToTable("Inventories");
        }
    }
}
