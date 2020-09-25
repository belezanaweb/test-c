using MediatR;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Contracts.Requests
{
    
    public sealed class CreateProductRequest : IRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("sku")]
        public long Sku { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }
}
