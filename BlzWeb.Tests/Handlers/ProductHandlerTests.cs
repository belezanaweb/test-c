using BlzWeb.Domain.StoreContext.Commands.ProductCommands.Inputs;
using BlzWeb.Domain.StoreContext.CustomerCommands.Inputs;
using BlzWeb.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlzWeb.Tests
{
    [TestClass]
    public class ProductHandlerTests
    {

        // Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada
        [TestMethod]
        public void NaoDevePermitirACriacaoDeProdutoComMesmoSku()
        {
            var command = new CreateProductCommand();
           var inventory = new InvertoryCommand();
            inventory.Quantity = 20;
            inventory.Warehouses = new List<WarehouseCommand>
            {
                new WarehouseCommand { Locality = "SP", Quantity = 5, Type = "ECOMMERCE" }
            };


            //_product = new Product(43264, , true, _inventory);
            command.Sku = 43264;
            command.Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
            

            var handler = new ProductHandler(new FakeProductrRepository());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(false, handler.IsValid);
        }

        // Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada
        [TestMethod]
        public void DevePermitirEAlterarOProduto()
        {
            var command = new UpdateProductCommand();
            var inventory = new InvertoryCommand();
            inventory.Quantity = 20;
            inventory.Warehouses = new List<WarehouseCommand>
            {
                new WarehouseCommand { Locality = "SP", Quantity = 5, Type = "ECOMMERCE" }
            };


            //_product = new Product(43264, , true, _inventory);
            command.Sku = 43264;
            command.Name = "Red Carpet Glow - Mousse Autobronzeador Corporal 140ml";
           
            var handler = new ProductHandler(new FakeProductrRepository());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
