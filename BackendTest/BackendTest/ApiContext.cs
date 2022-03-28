using BackendTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTest
{
    public class ApiContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}
