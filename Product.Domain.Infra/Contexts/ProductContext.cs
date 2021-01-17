using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Product.Domain.Entities;
using Product.Domain.Infra.Mapping;
using System;

namespace Product.Domain.Infra.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouses> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            new ProductMap(modelBuilder);
            new InventoryMap(modelBuilder);
            new WirehousesMap(modelBuilder);
        }
    }
}
