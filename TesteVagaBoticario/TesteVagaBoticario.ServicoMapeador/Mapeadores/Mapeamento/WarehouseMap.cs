using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteVagaBoticario.Negocio;

namespace TesteVagaBoticario.ServicoMapeador.Mapeadores.Mapeamento
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {

            builder.Property(warehouse => warehouse.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(warehouse => warehouse.IdInventory)
                .IsRequired();

            builder.Property(warehouse => warehouse.Locality)
                .IsRequired();

            builder.Property(warehouse => warehouse.Quantity)
              .IsRequired();

            builder.Property(warehouse => warehouse.Type)
                .IsRequired();
        }
    }
}
