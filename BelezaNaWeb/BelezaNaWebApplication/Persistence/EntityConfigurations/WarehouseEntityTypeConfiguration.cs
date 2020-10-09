using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BelezaNaWebApplication.Persistence.EntityConfigurations
{
    internal class WarehouseEntityTypeConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable(nameof(Inventory));

            builder.HasKey(o => o.Id);

            builder
                .Property<String>(nameof(Warehouse.Locality))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Locality));

            builder
                .Property<long>(nameof(Warehouse.Quantity))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Quantity));

            builder
                .Property<string>(nameof(Warehouse.Type))
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasColumnName(nameof(Warehouse.Type));

            builder.HasOne<Inventory>(x => x.Inventory)
                .WithMany(x => x.Warehouses)
                .HasForeignKey(x => x.InventoryId);
        }
    }
}