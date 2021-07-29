using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BWEBTestBack.Business.Models;

namespace BWEBTestBack.Data.Context
{
    public class BWEBTestContext : DbContext
    {
        public BWEBTestContext(DbContextOptions<BWEBTestContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BWEBTestContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
