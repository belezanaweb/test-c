using BlzWeb.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlzWeb.Tests
{
    [TestClass]
    public class ProductTests
    {
        private Product _product;
        private Inventory _inventory;
      

        public ProductTests()
        {
            _inventory = new Inventory(15M);
            _product = new Product(43264, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g", _inventory);
        }

        //Consigo criar um novo produto
        [TestMethod]
        public void OProdutoDeveSerValido()
        {
            Assert.AreEqual(true, _product.IsValid);
        }

        // Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: inventory.quantity
        // A propriedade inventory.quantity é a soma da quantity dos warehouses
        [TestMethod]
        public void TodaVezQueUmProdutoForRecuperadoPorSkuDeveraSerCalculadoAPropriedadeinventoryQuantity()
        {
            _product.CalculateInventory();
            Assert.AreNotEqual(_inventory.Quantity, _product.Inventory.Quantity);
        }

        // Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: isMarketable
        //Um produto é marketable sempre que seu inventory.quantity for maior que 0
        [TestMethod]
        public void TodaVezQueUmProdutoForRecuperadoPorSkuDeveraSerCalculadoAPropriedadeisMarketable()
        {
            _product.ChangeIsMarketable();
            Assert.IsTrue(_product.IsMarketable);
        }

        //Ao atualizar um produto, o antigo deve ser sobrescrito com o que esta sendo enviado na requisição
        //A requisição deve receber o sku e atualizar com o produto que tbm esta vindo na requisição
        [TestMethod]
        public void AoAtualizarUmProdutoDeveSObreecreverOAntigo()
        {
            _inventory = new Inventory(10M);
            _product = new Product(12345, "Make Up 03 Bege - Pó Compacto Matte 9g", _inventory);
            Assert.AreNotEqual(43264, _product.Sku);
        }
    }
}