
using BelezaNaWeb.Data.Mappings;
using BelezaNaWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Data.Context
{
    public class BelezaNaWebContext :  DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            //modelBuilder.AddConfiguration(new Mapping());
            
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
