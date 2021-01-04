using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApi.Models;

namespace TesteApi
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }
              
        public DbSet<Product> Products { get; set; }     
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Product>().HasKey(k => k.Sku);

            modelBuilder.Entity<Warehouse>().HasKey(k => k.Id);           

            modelBuilder.Entity<Inventory>(i =>
            {
                i.HasKey(k => k.Id);
                i.HasMany(i => i.Warehouses)
                    .WithOne(w => w.Inventory);
            });
        }
    }
}
