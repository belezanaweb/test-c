using DesafioBelezaNaWeb.Models;
using DesafioBelezaNaWeb.Repository;
using System.Collections.Generic;
using Xunit;

namespace DesafioBelezaNaWeb.Test
{
    public class BelezaNaWebBackendTest
    {
        private readonly ProductRepository _repository;
        private Product _product;
        private List<Warehouses> _warehouses;

        public BelezaNaWebBackendTest()
        {
            _repository = new ProductRepository();
            
            _product = new Product();
            _product.Sku = 43264;
            _product.Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";

            _warehouses = new List<Warehouses>();
            _warehouses.Add(new Warehouses()
            {
                Locality = "SP",
                Quantity = 12,
                Type = "ECOMMERCE"
            });
            _warehouses.Add(new Warehouses()
            {
                Locality = "MOEMA",
                Quantity = 3,
                Type = "ECOMMERCE"
            });

            Inventory inventory = new Inventory();
            inventory.Warehouses = _warehouses;
            
            _product.Inventory = inventory;
        }

        [Fact]
        public void Get_Product_Send_Sku_Return_Quantity_And_IsMarketable_True()
        {
            _repository.CreateProduct(_product);

            var (exists, product) = _repository.GetProduct(43264);

            Assert.True(exists);
            Assert.Equal(15, product.Inventory.Quantity);
            Assert.True(product.IsMarketable);
        }

        [Fact]
        public void Create_Product_And_Return_Product()
        {
            _repository.CreateProduct(_product);

            var produto = _repository.GetProduct(43264);

            Assert.Equal(43264, _product.Sku);
        }

        [Fact]
        public void Edit_Product_Name_And_Verify_If_Product_Is_Changed()
        {
            _repository.CreateProduct(_product);

            _product.Name = "NOME EDITADO";

            _repository.EditProduct(_product);

            var (exists, product) = _repository.GetProduct(43264);

            Assert.Equal(43264, product.Sku);
            Assert.Equal("NOME EDITADO", product.Name);
        }

        [Fact]
        public void DeleteProduct_WithSku_CallGetProduct_And_Return_False()
        {
            _repository.CreateProduct(_product);

            _repository.DeleteProduct(43264);

            var (exists, product) = _repository.GetProduct(43264);

            Assert.False(exists);
        }
    }
}