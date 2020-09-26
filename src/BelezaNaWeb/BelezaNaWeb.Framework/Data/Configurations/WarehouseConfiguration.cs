using System.Collections.Generic;
using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Framework.Data.Configurations
{
    internal sealed class WarehouseConfiguration : EntityConfiguration<Warehouse>
    {
        #region Overriden Methods

        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouses");

            builder.HasKey(p => new { p.Sku, p.Locality, p.Type });
            builder.Property(p => p.Sku).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Locality).IsRequired();
            builder.Property(p => p.Type).IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Warehouses).OnDelete(DeleteBehavior.Restrict);
        }

        public override IEnumerable<Warehouse> Seed()
            => new Warehouse[] {
                new Warehouse(sku: 43264, quantity: 12, locality: "SP",    type: "ECOMMERCE"),
                new Warehouse(sku: 43264, quantity:  3, locality: "MOEMA", type: "PHYSICAL_STORE"),
            };

        #endregion
    }
}
