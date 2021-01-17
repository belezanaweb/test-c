using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Domain.Commands;
using Product.Domain.Handlers;
using Product.Domain.Repositories;

namespace Product.Domain.Tests.Repositories
{
    [TestClass]
    public class FakeProductRepository : IProductRepository
    {
        public FakeProductRepository()
        {
                
        }

        public void Create(Entities.Product product)
        {
            
        }

        public void Delete(Entities.Product product)
        {
            
        }

        public Entities.Product GetBySku(int sku)
        {
            if (sku > 0)
                return new Entities.Product(1234, "Produto Teste", new Entities.Inventory());
            else
                return new Entities.Product();
        }

        public void Update(Entities.Product product)
        {
           
        }
    }
}
