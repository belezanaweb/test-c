using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Application
{
    public class ProductApplication : IProductApplication
    {
        #region Properties

        private readonly INotificator _notificator;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductApplication(INotificator notificator, IProductRepository productRepository)
        {
            _notificator = notificator;
            _productRepository = productRepository;
        }

        #endregion

        #region Public Methods

        public IList<Product> GetAll()
        {
            throw new System.Exception("Error GetAll()");
            var products = _productRepository.GetAll()?.Select(x => SetProductWarehousesQuantity(x)).ToList();

            return products;
        }

        public Product GetBySku(uint sku)
        {
            var product = _productRepository.GetBySku(sku);

            if (product == null)
                _notificator.AddError($"Produto (Sku: {sku}) não encontrado.");
            else
                SetProductWarehousesQuantity(product);

            return product;
        }

        public Product Create(Product product)
        {
            var productResponse = _productRepository.GetBySku(product.Sku);

            if (productResponse != null)
            {
                _notificator.AddError($"Produto (Sku: {product.Sku}) já cadastrado.");
            }
            else
            {
                productResponse = _productRepository.Create(product);

                if (productResponse == null)
                    _notificator.AddError($"Falha ao cadastrar o produto (Sku: {product.Sku}).");
                else
                    SetProductWarehousesQuantity(productResponse);
            }

            return productResponse;
        }

        public Product Update(Product product)
        {
            var productResponse = _productRepository.Update(product);

            if (productResponse == null)
                _notificator.AddError($"Falha ao atualizar o produto (Sku: {product.Sku}).");
            else
                SetProductWarehousesQuantity(productResponse);

            return productResponse;
        }

        public bool DeleteBySku(uint sku)
        {
            var response = _productRepository.DeleteBySku(sku);

            if (!response)
                _notificator.AddError($"Erro ao excluir o produto (Sku: {sku}).");

            return response;
        }

        #endregion

        #region Private Methods

        private static Product SetProductWarehousesQuantity(Product product)
        {
            if ((bool)product.Inventory?.Warehouses?.Any())
            {
                product.Inventory.Quantity = (uint)product.Inventory.Warehouses.Sum(x => x.Quantity);

                SetProductIsMarketable(product);
            }

            return product;
        }

        private static Product SetProductIsMarketable(Product product)
        {
            product.IsMarketable = product.Inventory?.Quantity > 0;

            return product;
        }

        #endregion
    }
}