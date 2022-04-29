using BackEndTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndTest.Infra.Data.EntitiesConfiguration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
