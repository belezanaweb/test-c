using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Boticario.Infra.Data.Entities;

namespace Boticario.Data.Context
{
    public class DefaultContext : DbContext
    {
        public string ConnectionString = "data source=MARCIO-NB\\SQLEXPRESS;initial catalog = Boticario; persist security info=True;Integrated Security = SSPI;";

        public DbSet<TabelaProduto> Produto { get; set; }
        public DbSet<TabelaEstoque> Estoque { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ConnectionString);
        }
    }
}