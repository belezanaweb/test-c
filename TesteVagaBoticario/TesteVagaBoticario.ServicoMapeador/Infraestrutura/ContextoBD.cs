using Microsoft.EntityFrameworkCore;
using TesteVagaBoticario.ServicoMapeador.Mapeadores.Mapeamento;

namespace TesteVagaBoticario.ServicoMapeador.Infraestutura
{
    public class ContextoBD : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("VagaBoticarioDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new InventoryMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
