using Microsoft.EntityFrameworkCore;
using Produto.Domain.Models;
using Produto.Infra.Extensions;
using Produto.Infra.Mapping;
using System;

namespace Produto.Infra.Contexts
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
        : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invenctory> Invenctories { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.AddConfiguration(new ProductConfiguration());
            builder.AddConfiguration(new InvenctoryConfiguration());
            builder.AddConfiguration(new WareHouseConfiguration());
            base.OnModelCreating(builder);                  

        }
    }
}
