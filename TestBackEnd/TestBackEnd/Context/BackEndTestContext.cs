using BackendTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.Context
{
    public class BackEndTestContext : DbContext
    {
        public BackEndTestContext(DbContextOptions<BackEndTestContext> options)
          : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(product =>
            {
                product.HasKey(p => p.Sku);
                product.HasIndex(p => p.Sku);
                product.Property(p => p.Sku).IsRequired();
                product.Property(p => p.Name).IsRequired();
                product.Property(p => p.IsMarketable).IsRequired();
            });

            modelBuilder.Entity<Inventory>(iventory =>
            {
                iventory.HasKey(i => i.Id);
                iventory.HasIndex(i => i.Id);
                iventory.Property(i => i.Quantity).IsRequired();                
                iventory.HasOne(i => i.Product).WithOne(p => p.Inventory).HasForeignKey<Inventory>(i => i.ProductId);
            });

            modelBuilder.Entity<WareHouse>(warehouse =>
            {
                warehouse.HasKey(w => w.Id);
                warehouse.HasIndex(w => w.Id);
                warehouse.Property(w => w.Locality).IsRequired();
                warehouse.Property(w => w.Quantity).IsRequired();
                warehouse.Property(w => w.Type).IsRequired();
                warehouse.HasOne(w => w.Inventory).WithMany(i => i.WareHouses).HasForeignKey(w => w.InventoryId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
