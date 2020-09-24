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

            builder.Property(p => p.Sku).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Locality).IsRequired();
        }

        #endregion
    }
}
