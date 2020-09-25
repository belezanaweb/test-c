using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class CreateProductCommand : CommandBase<CreateProductResult>
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public CreateProductCommand(long sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        #endregion
    }

    public sealed class CreateProductResult
    {
        #region Public Properties

        [JsonProperty("sku")]
        public long Sku { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }
}
