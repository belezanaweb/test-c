using belezanaweb.Domain.Entities;
using belezanaweb.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace belezanaweb.Infra.Data.Context
{
    public class BelezanawebContext : DbContext
    {
        public BelezanawebContext(DbContextOptions<BelezanawebContext> options)
            : base(options)
        {
            //creates database and applies initial migration
            Database.Migrate();            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new InventoryMapping());
            modelBuilder.ApplyConfiguration(new WarehouseMapping());            
        }     
    }
}
