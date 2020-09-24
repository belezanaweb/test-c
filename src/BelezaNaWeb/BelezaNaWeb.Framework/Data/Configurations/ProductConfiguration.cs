using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Framework.Data.Configurations
{
    internal sealed class ProductConfiguration : EntityConfiguration<Product>
    {
        #region Overriden Methods

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.Property(p => p.Name).IsRequired();

            builder.HasKey(p => p.Sku);
            builder.HasMany(p => p.Warehouses)
                .WithOne().HasForeignKey(p => p.Sku);
        }

        #endregion
    }
}
