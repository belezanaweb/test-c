using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Interfaces.Entities
{
    public interface IPagedListEntity<TEntity>
            where TEntity : class, IEntity
    {
        #region Public Propeties

        int Total { get; set; }
        int PageSize { get; set; }
        int PageIndex { get; set; }
        IEnumerable<TEntity> Collection { get; set; }

        #endregion
    }
}
