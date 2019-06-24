using BelezanaWeb.Model;
using BelezanaWeb.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BelezanaWeb.Infrastructure.Data.Context
{
    public class BelezanaWebContext : DbContext
    {
        public BelezanaWebContext(DbContextOptions<BelezanaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(AppSettings.ConnectionString.BelezanaWebDatabase);
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}
