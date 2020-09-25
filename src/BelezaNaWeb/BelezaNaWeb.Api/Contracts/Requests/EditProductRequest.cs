using MediatR;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BelezaNaWeb.Api.Contracts.Requests
{
    public sealed class EditProductRequest : IRequest
    {
        #region Public Properties

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
    }
}
