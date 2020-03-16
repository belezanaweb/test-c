using BelezaNaWeb.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Infrastructure.Data.Context
{
    public class BelezaNaWebContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("BelezaNaWeb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new InventoryMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
