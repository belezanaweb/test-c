using DemoTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoTest.Infra
{
    public class ContextRepository : DbContext
    {
        public ContextRepository(DbContextOptions<ContextRepository> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Inventario>().ToTable("Inventarios");
            builder.Entity<Inventario>().HasKey(p => p.Id);
            builder.Entity<Inventario>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Inventario>().Property(p => p.Localidade).HasMaxLength(30); 
            builder.Entity<Inventario>().Property(p => p.Tipo).HasMaxLength(30);

            builder.Entity<Produto>().ToTable("Produtos");            
            builder.Entity<Produto>().HasKey(p => p.Sku);
            builder.Entity<Produto>().Property(p => p.Sku).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Entity<Produto>().Ignore(p => p.Inventario);
        }
    }
}
