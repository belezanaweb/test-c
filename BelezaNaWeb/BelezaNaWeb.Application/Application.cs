using System;
using System.Collections.Generic;
using System.Linq;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Repository;

namespace BelezaNaWeb.Application
{
    public class ProductApp : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        
        public ProductApp(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public void CreateProduct(Product productParam)
        {
            try
            {
                if (productParam.Sku < 1)
                    throw new ArgumentException("Número do Sku inválido.");

                if (string.IsNullOrEmpty(productParam.Name))
                    throw new ArgumentException("Campo obrigatório. Por favor, preencher!");

                var product = _productRepository.GetBySkuNumber(productParam.Sku);

                if (product != null)
                    throw new ArgumentException($"Já existe um produto com o Sku informado.");

                _productRepository.CreateProduct(productParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProductBySkuNumber(int sku)
        {
            try
            {
                _productRepository.DeleteProductBySkuNumber(sku);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAllProducts();

                foreach (var item in products)
                    CalcInvetoryQuantity(item);

                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductBySku(int sku)
        {
            try
            {
                var product = _productRepository.GetBySkuNumber(sku);
                CalcInvetoryQuantity(product);

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Product productParam)
        {
            try
            {
                _productRepository.UpdateProduct(productParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalcInvetoryQuantity(Product product)
        {
            try
            {
                if (product?.Inventory != null && product.Inventory.Warehouses.Any())
                {
                    product.Inventory.Quantity = product.Inventory.Warehouses.Sum(x => x.Quantity);
                    VerifyIfIsMarketable(product);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void VerifyIfIsMarketable(Product product)
        {
            try
            {
                if (product.Inventory.Quantity > 0)
                    product.IsMarketable = true;
                else
                    product.IsMarketable = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}