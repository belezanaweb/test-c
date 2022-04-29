using AutoMapper;
using BackEndTest.Application.DTOs;
using BackEndTest.Application.Interfaces;
using BackEndTest.Domain.Entities;
using BackEndTest.Domain.Interfaces;

namespace BackEndTest.Application.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        /** Verifica existência de SKU
         * True se for repetido
         * False caso contrário
         * */
        public bool CheckExistingSku(int sku)
        {
            var skuList = _productRepository.GetAllProductSku();
            return skuList.Contains(sku);
        }

        public async Task<bool> CreateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            return await _productRepository.CreateProductAsync(productEntity);
        }

        public async Task<ProductDTO> GetProductBySku(int sku)
        {
            Product productEntity = await _productRepository.GetProductBySkuAsync(sku);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<bool> RemoveProductBySku(int sku)
        {
            return await _productRepository.RemoveProductBySkuAsync(sku);
        }

        public async Task<bool> UpdateProductBySku(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            return await _productRepository.UpdateProductBySkuAsync(productEntity);

        }
    }
}
