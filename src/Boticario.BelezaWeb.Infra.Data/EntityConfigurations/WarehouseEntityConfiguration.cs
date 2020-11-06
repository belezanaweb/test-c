using Boticario.BelezaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.BelezaWeb.Infra.Data.EntityConfigurations
{
	public class WarehouseEntityConfiguration : IEntityTypeConfiguration<Warehouse>
	{
		public void Configure(EntityTypeBuilder<Warehouse> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.InventoryId).IsRequired();
			builder.Property(p => p.Locality).HasMaxLength(100).IsRequired();
			builder.Property(p => p.Quantity).IsRequired();
			builder.Property(p => p.Type).HasMaxLength(50).IsRequired();
		}
	}
}
