using Microsoft.EntityFrameworkCore;

namespace ProjetoBoticario.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }
    

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().HasKey(p => new { p.Id, p.Sku });
        }
    }
}