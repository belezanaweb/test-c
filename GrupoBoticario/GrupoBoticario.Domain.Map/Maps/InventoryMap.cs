using GrupoBoticario.Domain.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Map.Maps
{
    public class InventoryMap : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            builder
                .ToTable("bw_inventory");

            builder
                .HasKey(p => p.Sku);

            builder
                .HasMany(p => p.WareHouses)
                .WithOne()
                .HasForeignKey(x => x.IdkeyReference);
        }
    }
}
