using GrupoBoticario.Domain.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.Map.Maps
{
    public class WareHouseMap : IEntityTypeConfiguration<WareHouseEntity>
    {
        public void Configure(EntityTypeBuilder<WareHouseEntity> builder)
        {
            builder
                .ToTable("bw_warehouse");

            builder
                .HasKey(w => w.Sku);

            builder
                .Property(w => w.Quantity);

            builder
                .Property(w => w.Locality)
                .HasMaxLength(20);

            builder
                .Property(w => w.TypeWareHouseId);

            builder
               .Ignore(x => x.TypeWareHouse);
        }
    }
}
