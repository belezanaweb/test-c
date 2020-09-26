using Newtonsoft.Json;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class DeleteProductCommand : CommandBase<bool>
    {
        #region Public Properties

        [JsonProperty("sku")]
        public int Sku { get; }

        #endregion

        #region Constructors

        public DeleteProductCommand(int sku)
            => Sku = sku;

        #endregion
    }
}
