using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Product.Domain.Entities;

namespace Product.Domain.Infra.Mapping
{
    public class InventoryMap
    {
        public InventoryMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
            modelBuilder.Entity<Inventory>().HasKey(x => x.Id);
            modelBuilder.Entity<Inventory>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>().Property(x => x.ProductId).IsRequired();

            modelBuilder.Entity<Inventory>().HasOne(x => x.Product).WithOne(x => x.Inventory).HasForeignKey<Inventory>(x => x.ProductId);
            modelBuilder.Entity<Inventory>().HasMany(x => x.Warehouses).WithOne(x=> x.Inventory);
        }
    }
}
