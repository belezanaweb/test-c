using System;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Framework.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaNaWeb.Framework.Helpers
{
    public sealed class DbGeneratorHelper
    {
        #region Public Static Methods

        public static void Create(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApiContext(serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                if (dbContext.Database.IsInMemory())
                    dbContext.Database.EnsureCreated();
            }
        }

        #endregion
    }
}
