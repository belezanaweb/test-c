using BelezaNaWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Infrastructure.Data.Mappings
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Locality)
                .IsRequired();

            builder.Property(c => c.Type)
                .IsRequired();

            builder.HasMany(d => d.Inventory)
                .WithOne(p => p.Warehouse)
                .HasForeignKey(d => d.IdWarehouse);


        }
    }
}
