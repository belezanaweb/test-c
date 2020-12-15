using System;
using System.Collections.Generic;
using System.Text;
using TesteBoticario.Domain.Dto;

namespace TesteBoticario.Domain.Repository
{
    public interface IProductRepository
    {
        void Add(Product product);

        void Update(Product product);

        bool Exists(int sku);

        Product Get(int sku);

        bool Delete(int sku);

        IEnumerable<Product> GetAllProducts();
    }
}
