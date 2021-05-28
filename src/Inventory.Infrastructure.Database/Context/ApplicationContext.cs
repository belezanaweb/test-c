using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new Configuration.ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.WarehouseConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
