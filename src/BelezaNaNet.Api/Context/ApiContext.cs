using BelezaNaNet.Api.Models;
using BelezaNaNet.Api.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace BelezaNaNet.Api.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Warehouse>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Product>(eb =>
            {
                eb.HasKey(p => p.Sku);
                var productsConfig = new ProductsConfiguration();
                productsConfig.Configure(eb);
            });
        }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<Warehouse> Warehouses { get; set; }
    }
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Inventory).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<Inventory>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
