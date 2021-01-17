using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Product.Domain.Entities;

namespace Product.Domain.Infra.Mapping
{
   public class ProductMap
    {
        public ProductMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Product>().ToTable("Product");           
            modelBuilder.Entity<Entities.Product>().HasKey(x=>  x.Id);

            modelBuilder.Entity<Entities.Product>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entities.Product>().Property(x => x.Sku).IsRequired();
            modelBuilder.Entity<Entities.Product>().HasIndex(x => x.Sku).IsUnique(true);

            modelBuilder.Entity<Entities.Product>().Property(x => x.Name).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)"); ;

            modelBuilder.Entity<Entities.Product>().HasOne(x => x.Inventory).WithOne(p=> p.Product).HasForeignKey<Inventory>(x=> x.ProductId);           
        }
    }
}
