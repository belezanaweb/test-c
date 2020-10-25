using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Tests.Mocks
{
    internal class ProductEntityMock : IProductEntity
    {
        public int Sku { get; set; }
        public string Name { get; set; }
    }
}
