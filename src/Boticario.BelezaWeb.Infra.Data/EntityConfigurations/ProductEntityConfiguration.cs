using Boticario.BelezaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boticario.BelezaWeb.Infra.Data.EntityConfigurations
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Ignore(p => p.Id);
			builder.Ignore(p => p.IsMarketable);

			builder.HasKey(p => p.Sku);
			builder.Property(p => p.Name).IsRequired().HasMaxLength(500);
			builder.HasOne(p => p.Inventory).WithOne(p => p.Product);
		}
	}
}
