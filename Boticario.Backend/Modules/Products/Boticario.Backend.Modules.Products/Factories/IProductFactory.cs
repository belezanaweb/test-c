using Boticario.Backend.Modules.Products.Models;

namespace Boticario.Backend.Modules.Products.Factories
{
    public interface IProductFactory
    {
        IProductEntity Create(int sku, string name);
    }
}
