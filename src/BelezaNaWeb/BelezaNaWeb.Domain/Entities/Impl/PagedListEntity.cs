using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BelezaNaWeb.Domain.Entities.Impl
{
    [DataContract]
    [Serializable]
    public sealed class PagedListEntity<TEntity> : IPagedListEntity<TEntity>
        where TEntity : class, IEntity
    {
        #region Public Properties

        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public IEnumerable<TEntity> Collection { get; set; }

        #endregion

        #region Constructors

        public PagedListEntity(int pageIndex, int pageSize)
            : this(pageIndex, pageSize, total: 0)
        { }

        public PagedListEntity(int pageIndex, int pageSize, int total)
        {
            Total = total;
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        #endregion
    }
}
