using Boticario.Backend.Modules.Products.Factories;
using Boticario.Backend.Modules.Products.Models;
using System;

namespace Boticario.Backend.Modules.Products.Implementation.Factories
{
    public class DefaultProductFactory : IProductFactory
    {
        public IProduct Create(int sku, string name)
        {
            throw new NotImplementedException();
        }
    }
}
