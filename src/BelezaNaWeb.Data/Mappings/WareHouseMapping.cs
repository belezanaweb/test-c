using BelezaNaWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Data.Mappings
{
    public class WareHouseMapping : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(EntityTypeBuilder<WareHouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Locality).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasOne(x => x.Inventory).WithMany(x => x.WareHouses).HasForeignKey(x => x.InventoryId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
