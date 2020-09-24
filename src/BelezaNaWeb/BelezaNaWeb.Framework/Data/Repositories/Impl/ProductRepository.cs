using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Data.Contexts;

namespace BelezaNaWeb.Framework.Data.Repositories.Impl
{
    public sealed class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Constructors

        public ProductRepository(ILogger<ProductRepository> logger, ApiContext dbContext)
            : base(logger, dbContext)
        { }

        #endregion
    }
}
