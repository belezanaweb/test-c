using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Framework.Business
{
    public interface IUnitOfWork
    {
        #region IUnitOfWork Members

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}
