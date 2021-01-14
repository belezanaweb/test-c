using BelezaNaWeb.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace BelezaNaWeb.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoConfig());
            builder.ApplyConfiguration(new InventarioConfig());

            base.OnModelCreating(builder);
        }
    }
}
