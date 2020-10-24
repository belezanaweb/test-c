using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Implementation.Models
{
    internal class Product : IProduct
    {
        public int Sku { get; set; }
        public string Name { get; set; }
    }
}
