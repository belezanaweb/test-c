using BNWTC.Api.Models.Entities;

using Microsoft.EntityFrameworkCore;

namespace BNWTC.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .HasKey(r => new { r.Id, r.Sku });
        }
    }
}
