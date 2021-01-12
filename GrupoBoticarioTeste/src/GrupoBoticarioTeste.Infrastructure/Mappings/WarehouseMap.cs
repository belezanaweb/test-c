using GrupoBoticarioTeste.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoBoticarioTeste.Infrastructure.Mappings
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder
                .HasKey(w => w.Id);

            builder
                .Property(w => w.Locality)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(w => w.Quantity)
                .IsRequired();

            builder
                .Property(w => w.Type)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}