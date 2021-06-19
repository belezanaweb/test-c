using BelezaNaWeb.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Sku)
                .IsUnique();
        }
    }
}
