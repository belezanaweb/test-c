using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class DeleteProductCommand : CommandBase<bool>
    {
        #region Public Properties

        [JsonProperty("sku")]
        public long Sku { get; }

        #endregion

        #region Constructors

        public DeleteProductCommand(long sku)
            => Sku = sku;

        #endregion
    }
}
