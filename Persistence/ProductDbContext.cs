using Microsoft.EntityFrameworkCore;
using TesteBelezaNaWeb.API.Core.Entities;

namespace TesteBelezaNaWeb.API.Persistence
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



    }
}
