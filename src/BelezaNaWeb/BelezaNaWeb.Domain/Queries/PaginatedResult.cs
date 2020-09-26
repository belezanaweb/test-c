using Newtonsoft.Json;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Queries
{
    public abstract class PaginatedResult<TDto>
        where TDto : class
    {
        #region Public Properties

        [JsonProperty("page")]
        public int Page { get; }

        [JsonProperty("offset")]
        public int Offset { get; }

        [JsonProperty("total")]
        public int Total { get; }

        [JsonProperty("data")]
        public IEnumerable<TDto> Data { get; set; }

        #endregion

        #region Constructors

        public PaginatedResult(int page, int offset, int total)
            : this(page, offset, total, data: null)
        { }

        public PaginatedResult(int page, int offset, int total, IEnumerable<TDto> data)
        {
            Page = page;
            Total = total;
            Offset = offset;
            Data = data ?? new List<TDto>();
        }

        #endregion
    }
}
