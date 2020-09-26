using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Requests
{
    public sealed class EditProductRequest : IBaseRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("name")]
        public string Name { get; }

        [Required]
        [JsonProperty("inventory")]
        public EditProductInventoryRequest Inventory { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public EditProductRequest(string name, EditProductInventoryRequest inventory)
        {
            Name = name;
            Inventory = inventory;
        }

        #endregion
    }

    public sealed class EditProductInventoryRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("warehouses")]
        public IEnumerable<EditProductWarehouseRequest> Warehouses { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public EditProductInventoryRequest(IEnumerable<EditProductWarehouseRequest> warehouses)
        {
            Warehouses = warehouses;
        }

        #endregion
    }

    public sealed class EditProductWarehouseRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("quantity")]
        public int Quantity { get; }

        [Required]
        [JsonProperty("locality")]
        public string Locality { get; }

        [Required]
        [JsonProperty("type")]
        public string Type { get; }

        #endregion

        #region Constructors

        [JsonConstructor]
        public EditProductWarehouseRequest(int quantity, string locality, string type)
        {
            Type = type;
            Quantity = quantity;
            Locality = locality;
        }

        #endregion
    }
}
