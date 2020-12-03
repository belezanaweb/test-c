using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using System;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.Models
{
    public class ResponseProductModel
    {
        public ProductModel Data { get; set; }
        public DateTime Requested { get; set; }
    }
}
