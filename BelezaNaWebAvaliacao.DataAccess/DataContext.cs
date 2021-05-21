using BelezaNaWebAvaliacao.Models;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWebAvaliacao.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
