using BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Enumerable;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;

namespace BrunoTragl.BelezaNaWeb.Tests.WebApi.ProductModelState.Factory
{
    public static class ProductFactory
    {
        public static ProductModel Create(StateProduct state)
        {
            switch (state)
            {
                case StateProduct.Bad:
                    return new BadProductBehavior().Get();
                case StateProduct.WithoutQuantity:
                    return new WithoutQuantityProductBehavior().Get();
                case StateProduct.WithQuantity:
                    return new WithQuantityProductBehavior().Get();
                default:
                    return null;
            }
        }
    }
}
