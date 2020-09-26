using Newtonsoft.Json;
using System;

namespace BelezaNaWeb.Domain.Dtos
{
    public sealed class WarehouseDto
    {
        #region Public Properties

        [JsonProperty("locality", Order = 0)]
        public string Locality { get; set; }

        [JsonProperty("quantity", Order = 1)]
        public int Quantity { get; set; }

        [JsonProperty("type", Order = 2)]
        public string Type { get; set; }

        #endregion

        #region Constructors

        public WarehouseDto(string locality, int quantity, string type)
        {
            Type = type;
            Locality = locality;
            Quantity = quantity;
        }

        #endregion

        #region Overriden Methods

        public override int GetHashCode()
            => base.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is WarehouseDto))
                return false;

            var other = (obj as WarehouseDto);

            return (
                Quantity == other.Quantity
                && Type.Equals(other.Type, StringComparison.OrdinalIgnoreCase)
                && Locality.Equals(other.Locality, StringComparison.OrdinalIgnoreCase)
            );
        }

        #endregion
    }
}
