using BelezaNaWeb.Data.Mappings;
using BelezaNaWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Data
{
    public class BelezaNaWebDbContext : DbContext
    {
        public BelezaNaWebDbContext(DbContextOptions<BelezaNaWebDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(new ProductMapping().Configure);
            modelBuilder.Entity<Inventory>(new InventoryMapping().Configure);
            modelBuilder.Entity<WareHouse>(new WareHouseMapping().Configure);
        }
    }
}
