using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModels;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Domain.Interfaces;

namespace BelezaNaWeb.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductAppService(IMapper mapper,
                                 IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        
        public ProductViewModel GetBySku(int sku)
        {
            var product = mapper.Map(productRepository.GetBySku(sku));
            if(product == null)
            {
                throw new DomainException($"Product {sku} not found.");
            }
            return product;
        }

        public void Register(ProductViewModel productViewModel)
        {
            var product = productRepository.GetBySku(productViewModel.Sku);

            if(product != null)
            {
                throw new DomainException($"Product {productViewModel.Sku} already exists.");
            }

            productRepository.Add(mapper.Map(productViewModel));
            productRepository.SaveChanges();
        }

        public void Remove(int sku)
        {
            var product = productRepository.GetBySku(sku);
            if(product != null)
            {
                productRepository.Remove(product.Id);
                productRepository.SaveChanges();
            }
            else
            {
                throw new DomainException($"Product {sku} not found.");
            }
        }

        public void Update(ProductViewModel productViewModel)
        {
            var product = productRepository.GetBySku(productViewModel.Sku);

            if(product != null)
            {
                productRepository.Remove(product.Id);
                productRepository.Add(mapper.Map(productViewModel));
                productRepository.SaveChanges();
            }
            else
            {
                throw new DomainException($"Product {productViewModel.Sku} not found.");
            }
        }
    }
}
