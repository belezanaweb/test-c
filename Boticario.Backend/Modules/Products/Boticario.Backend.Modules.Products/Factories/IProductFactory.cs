using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Factories
{
    public interface IProductFactory
    {
        IProduct Create(int sku, string name);
    }
}
