using BoticarioAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoticarioAPI.Infra.Context
{
    public class BoticarioContext : DbContext
    {
        public BoticarioContext(DbContextOptions<BoticarioContext> options)
        : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
