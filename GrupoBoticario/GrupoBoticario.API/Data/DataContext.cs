using GrupoBoticario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoBoticario.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
