using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Product.Domain.Entities;

namespace Product.Domain.Infra.Mapping
{
    public class WirehousesMap
    {
        public WirehousesMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouses>().ToTable("Warehouse");
            modelBuilder.Entity<Warehouses>().HasKey(x=> x.Id);
            modelBuilder.Entity<Warehouses>().Property(x => x.Id);
            modelBuilder.Entity<Warehouses>().Property(x => x.Locality).IsRequired().HasMaxLength(150).HasColumnType("varchar(150)");
            modelBuilder.Entity<Warehouses>().Property(x => x.Quantity).IsRequired();
            modelBuilder.Entity<Warehouses>().Property(x => x.Type).IsRequired().HasMaxLength(150).HasColumnType("varchar(150)");

            modelBuilder.Entity<Warehouses>().HasOne(x => x.Inventory).WithMany(w => w.Warehouses).HasForeignKey(x=> x.InventoryId);
        }
    }
}
