using Microsoft.EntityFrameworkCore;


namespace Business.Entity
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
    }
}