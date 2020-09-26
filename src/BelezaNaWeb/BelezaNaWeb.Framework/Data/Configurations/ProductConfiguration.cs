using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Domain.Entities.Impl;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Framework.Data.Configurations
{
    internal sealed class ProductConfiguration : EntityConfiguration<Product>
    {
        #region Overriden Methods

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Sku);
            builder.Property(p => p.Sku).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }

        public override IEnumerable<Product> Seed()
            => new Product[] {
                new Product(sku: 43264, name: "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g")
            };
    
        #endregion
    }
}
