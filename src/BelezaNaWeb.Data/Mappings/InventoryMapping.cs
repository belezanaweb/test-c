using BelezaNaWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BelezaNaWeb.Data.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithOne(x => x.Inventory).HasForeignKey<Inventory>(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
