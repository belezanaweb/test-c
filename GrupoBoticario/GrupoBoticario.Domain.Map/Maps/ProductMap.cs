using GrupoBoticario.Domain.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Map.Maps
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("bw_product");

            builder.HasKey(p => p.Sku);

            builder.Property(p => p.Name)
                    .HasMaxLength(90);

            builder.HasOne(p => p.Inventory)
                  .WithOne()
                  .HasForeignKey<InventoryEntity>(c => c.IdkeyReference);
        }
    }
}
