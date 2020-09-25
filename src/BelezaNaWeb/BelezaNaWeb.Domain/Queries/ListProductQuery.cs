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

    public sealed class ListProductResult
    {
        #region Public Properties

        [JsonProperty("data")]
        public IEnumerable<ProductDto> Data { get; set; }

        #endregion
    }
}
