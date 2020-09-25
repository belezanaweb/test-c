using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Domain.Queries
{
    public sealed class GetProductQuery : QueryBase<GetProductResult>
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public GetProductQuery(long sku)
            => Sku = sku;

        #endregion
    }

    public sealed class GetProductResult
    {
        #region Public Properties

        [JsonProperty("sku")]
        public long Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }
}
