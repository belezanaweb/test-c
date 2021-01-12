using GrupoBoticarioTeste.Business.Models;
using GrupoBoticarioTeste.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GrupoBoticarioTeste.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());
        }
    }

}
