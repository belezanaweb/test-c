using Boticario.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.Infrastructure.Configurations
{
    public class WarehouseConfigurations : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(warehouse => warehouse.Id);
        }
    }
}
