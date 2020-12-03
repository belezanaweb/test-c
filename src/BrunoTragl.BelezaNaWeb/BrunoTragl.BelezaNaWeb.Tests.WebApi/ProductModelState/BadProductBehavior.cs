using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Base;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState
{
    public class BadProductBehavior : ProductBase
    {
        protected override void CreateProduct()
        {
            Product = new ProductModel
            {
                Name = null,
                Inventory = null
            };
        }
    }
}
