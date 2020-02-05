
using BelezaNaWeb.Data.Mappings;
using BelezaNaWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Data.Context
{
    public class BelezaNaWebContext :  DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { optionsBuilder.UseInMemoryDatabase(databaseName:"BelezaNaWebProdutos"); }
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new InventoryMapping());
            modelBuilder.ApplyConfiguration(new WarehouseMapping());



            base.OnModelCreating(modelBuilder);
        }
    }
}
