using BelezaNaWeb.Core.Model;
using BelezaNaWeb.Core.Repositories;
using BelezaNaWeb.Core.Services;

namespace BelezaNaWeb.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {

            return _productRepository.Add(product);
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public Product GetProductBySku(int sku)
        {
            return _productRepository.GetProductBySku(sku);
        }

        public bool Delete(int sku)
        {
            return _productRepository.Delete(sku);
        }
    }
}
