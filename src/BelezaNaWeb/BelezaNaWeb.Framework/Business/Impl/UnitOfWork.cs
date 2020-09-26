using System;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Framework.Data.Contexts;

namespace BelezaNaWeb.Framework.Business.Impl
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Private Read-Only Fields

        private readonly ApiContext _dbContext;

        #endregion

        #region Constructors

        public UnitOfWork(ApiContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        #endregion

        #region IUnitOfWork Members

        public int Complete()
            => _dbContext.SaveChanges();

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken);

        #endregion
    }
}
