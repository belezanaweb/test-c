using Produto.Domain.Models;
using Produto.Domain.Notifications;
using Produto.Domain.Repositories;
using Produto.Domain.Services;
using System;

namespace Produto.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProdutoRepository productRepository;
        private readonly NotificationContext notificationContext;

        public ProductService(IProdutoRepository produtoRepositoryParameter, NotificationContext notificationContextParameter)
        {
            this.productRepository = produtoRepositoryParameter;
            this.notificationContext = notificationContextParameter;

        }
        public Product AddAsync(Product product)
        {

            if (product.Valid)
            {
                var productAlreadyFound = this.productRepository.FindBy(product.Sku);
                if (productAlreadyFound != null)
                {
                    this.notificationContext.AddNotification("Ja existe outro produto com o sku informado");
                    return default;
                }

                productRepository.AddAsync(product);
                return product;
            }
            else
            {
                this.notificationContext.AddNotifications(product.ValidationResult);
                return default;
            }

        }

        public Product FindBy(string sku)
        {
            Product product;

            product = productRepository.FindBy(sku);

            if (product == null)
                this.notificationContext.AddNotification("Produto nao encontrado");
            return product;

        }


        public bool Remove(String sku)
        {
            var productManager = productRepository.FindBy(sku);
            if (productManager != null)
                return productRepository.Remove(productManager);
            else
            {
                notificationContext.AddNotification("Produto que esta sendo atualizado nao existe");
                return false;
            }

        }

        public Product Update(int id, Product product)
        {
            if (id != product.Id)
            {
                notificationContext.AddNotification("Produto nao encontrado.");

                return default;
            }
        
            productRepository.Update(product);
            return product;

        }
    }
}
