using Newtonsoft.Json;
using BelezaNaWeb.Domain.Dtos;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Queries
{
    public sealed class ListProductQuery : QueryBase<ListProductResult>
    {
        #region Public Properties

        [JsonProperty("page")]
        public int Page { get; } = 1;

        [JsonProperty("offset")]
        public int Offset { get; } = 10;

        #endregion

        #region Constructors

        [JsonConstructor]
        public ListProductQuery(int page, int offset)
        {
            Page = page;
            Offset = offset;
        }

        #endregion
    }

    public sealed class ListProductResult : PaginatedResult<ProductDto>
    {
        #region Constructors

        public ListProductResult(int page, int offset, int total)
            : base(page, offset, total, data: null)
        { }

        public ListProductResult(int page, int offset, int total, IEnumerable<ProductDto> data)
            : base(page, offset, total, data)
        { }

        #endregion
    }
}
