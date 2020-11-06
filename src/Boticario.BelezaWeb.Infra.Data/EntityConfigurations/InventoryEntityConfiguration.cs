using Boticario.BelezaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.BelezaWeb.Infra.Data.EntityConfigurations
{
	public class InventoryEntityConfiguration : IEntityTypeConfiguration<Inventory>
	{
		public void Configure(EntityTypeBuilder<Inventory> builder)
		{
			builder.Ignore(p => p.Quantity);
			builder.HasKey(p => p.Id);
			builder.Property(p => p.ProductSku).IsRequired();
			builder.HasMany(p => p.Warehouses).WithOne(p => p.Inventory);
		}
	}
}
