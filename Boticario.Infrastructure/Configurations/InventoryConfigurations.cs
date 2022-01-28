using Boticario.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.Infrastructure.Configurations
{
    public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(inventory => inventory.Id);

            builder
                .HasMany(inventory => inventory.Warehouses)
                .WithOne()
                .HasForeignKey(warehouse => warehouse.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
