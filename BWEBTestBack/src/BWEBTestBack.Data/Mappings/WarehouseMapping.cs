using BWEBTestBack.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWEBTestBack.Data.Mappings
{
    public class WarehouseMapping : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Locality)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(w => w.Quantity)
                .IsRequired();

            builder.Property(w => w.Type)
                .IsRequired();

            builder.ToTable("Warehouses");
    }
    }
}
