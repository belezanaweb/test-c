using Boticario.Test.Application.Entity;
using Microsoft.EntityFrameworkCore;

namespace Boticario.Test.Infrastructure.Context
{
    public class SkuContext : DbContext
    {
        public DbSet<Product> Sku { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        public SkuContext(DbContextOptions options) : base(options)
        {
            
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sku = modelBuilder.Entity<Product>();
            sku.HasKey(x => x.Id);

            var inventory = modelBuilder.Entity<Inventory>();
            inventory.HasKey(x => x.Id);
            inventory.HasOne(x => x.Sku)
                .WithOne(x => x.Inventory)
                .OnDelete(DeleteBehavior.Cascade);

            var warehouse = modelBuilder.Entity<Warehouse>();
            warehouse.HasKey(x => x.Id);
            warehouse.HasOne(x => x.Inventory)
                .WithMany(x => x.Warehouses)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}