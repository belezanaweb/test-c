using BelezaNaWebApplication.Persistence.EntityConfigurations;
using BelezaNaWebDomain;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWebApplication.Persistence.Contexts
{
    public class MemoryDbContext : DbContext
    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseEntityTypeConfiguration());

            //List<Warehouse> warehouses = new List<Warehouse>();
            //warehouses.Add(new Warehouse()
            //{
            //    Locality = "SP",
            //    Quantity = 12,
            //    Type = WarehouseType.ECOMMERCE
            //});
            //warehouses.Add(new Warehouse()
            //{
            //    Locality = "MOEMA",
            //    Quantity = 3,
            //    Type = WarehouseType.PHYSICAL_STORE
            //});

            //modelBuilder.Entity<Warehouse>().HasData
            //(
            //    warehouses.ToArray()
            //);

            //Inventory inventory = new Inventory()
            //{
            //    Warehouses = warehouses.ToArray()
            //};

            //var product = new Product
            //{
            //    SKU = "43264",
            //    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            //    Inventory = inventory
            //};

            //modelBuilder.Entity<Inventory>().HasData
            //(
            //    inventory
            //);

            //modelBuilder.Entity<Product>().HasData
            //(
            //    product
            //);
        }
    }
}