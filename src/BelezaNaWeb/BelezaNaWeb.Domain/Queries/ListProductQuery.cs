using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Queries
{
    public sealed class ListProductQuery : QueryBase<ListProductResult>
    {
        #region Public Properties

        [JsonProperty]
        public int Page { get; } = 1;

        [JsonProperty]
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

    }
}
