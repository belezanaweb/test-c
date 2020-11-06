using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Boticario.BelezaWeb.Infra.Data.Contexts
{
	public class BelezaWebDbContext : DbContext
	{
		public BelezaWebDbContext(DbContextOptions<BelezaWebDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Product { get; set; }
		public DbSet<Inventory> Inventory { get; set; }
		public DbSet<Warehouse> Warehouse { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
			modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
			modelBuilder.ApplyConfiguration(new WarehouseEntityConfiguration());
		}
	}
}
