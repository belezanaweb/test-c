using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Framework.Extensions;

namespace BelezaNaWeb.Framework.Data.Contexts
{
    public sealed class ApiContext : DbContext
    {
        #region Constructors

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        { }

        #endregion

        #region Overriden Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");            
            modelBuilder.LoadAllConfigurations();
            modelBuilder.RemoveCascadeDeleteConvention();
        }

        #endregion
    }
}
