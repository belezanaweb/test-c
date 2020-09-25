using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class EditProductCommand : CommandBase<bool>
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public EditProductCommand(long sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        #endregion
    }
}
