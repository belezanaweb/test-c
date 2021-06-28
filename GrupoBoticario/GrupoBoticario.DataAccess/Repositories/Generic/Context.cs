using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.Map.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.DataAccess.Repositories.Generic
{
    public class Context : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<InventoryEntity> Inventory { get; set; }
        public DbSet<WareHouseEntity> WareHouse { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);
            //modelBuilder.Entity<InventoryEntity>(new InventoryMap().Configure);
            //modelBuilder.Entity<WareHouseEntity>(new WareHouseMap().Configure);
            
            modelBuilder.Entity<ProductEntity>().HasKey(x => x.Sku);
            modelBuilder.Entity<InventoryEntity>().HasKey(x => x.Sku);
            modelBuilder.Entity<WareHouseEntity>().HasKey(x => x.Sku);

            base.OnModelCreating(modelBuilder);
        }
    }
}
