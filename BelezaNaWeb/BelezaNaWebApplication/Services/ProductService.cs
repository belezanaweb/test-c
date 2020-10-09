using BelezaNaWebDomain;
using BelezaNaWebDomain.Repositories;
using BelezaNaWebDomain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (!(product?.SKU > 0))
                throw new Exception("SKU não encontrado!");

            var productGet = _productRepository.FindByIdAsync(product.SKU.Value);
            if (productGet.Result?.SKU > 0)
                throw new Exception($"Produto já existente, não é possível adicionar SKU {productGet.Result?.SKU} duplicado! Dois produtos são considerados iguais se os seus skus forem iguais.");

            _productRepository.AddAync(product);
        }

        public void DeleteProduct(long sku)
        {
            var productGet = _productRepository.FindByIdAsync(sku);
            if (!(productGet.Result?.SKU > 0))
                throw new Exception($"Produto não existente, não é possível deletar produto com SKU {sku}!");

            _productRepository.Remove(productGet.Result);
        }

        public async Task<Product> GetProductAsync(long sku)
        {
            return await _productRepository.FindByIdAsync(sku);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public void UpdateProduct(Product product)
        {
            if (!(product?.SKU > 0))
                throw new Exception("Produto incompleto, sem SKU!");

            var productGet = _productRepository.FindByIdAsync(product.SKU.Value);
            if (productGet.Result?.SKU > 0)
            {
                var existsProduct = productGet.Result;
                existsProduct.Name = product.Name;
                existsProduct.Inventory = product.Inventory;
                _productRepository.Update(existsProduct);
            }
            else
                throw new Exception($"Produto não encontrado com SKU {product?.SKU}!");
        }
    }
}