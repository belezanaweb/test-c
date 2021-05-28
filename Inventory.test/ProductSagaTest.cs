using Inventory.Core.Notification;
using Inventory.Domain.Handlers;
using Inventory.Domain.Queries;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.test
{
    public class ProductSagaTest
    {
        [Fact]
        public void When_the_createproductcommand_with_valid_product_is_provided_than_it_is_storaged_on_the_repository()
        {
            var mockMediator = new Mock.MediatorHandlerMock();
            var mock = new test.Mock.RepositoryMock();
            var list = new List<Core.Product>();
            var repository = mock.Create(list);
            var notifiable = new Notifiable<Domain.Events.DomainErrorRaised>();
            List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
            notifiable.Handle += (notification, token) =>
            {
                errors.AddRange(notification.Errors);
                return Task.CompletedTask;
            };
            var mediator = mockMediator.Create(notifiable);
            Domain.Commands.CreateProductCommand command = new Domain.Commands.CreateProductCommand(1000, "teste", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse> { }
            });
            var productSaga = new ProductSaga(repository, list.AsQueryable(), mediator);
            var task = productSaga.Handle(command, default);
            task.Wait();
            mock.Context().Verify(item => item.Add(It.IsAny<Core.Product>()), Times.Once());
            Assert.True(list.Count.Equals(1));
            Assert.True(errors.Count.Equals(0));

        }

        [Fact]
        public void When_the_createproductcommand_with_a_sku_already_storaged_is_provided_than_the_add_method_shoul_be_called_once_and_an_error_sku_duplicated_should_be_raised()
        {
            var mockMediator = new Mock.MediatorHandlerMock();
            var mock = new test.Mock.RepositoryMock();
            var list = new List<Core.Product>();
            var repository = mock.Create(list);
            var notifiable = new Notifiable<Domain.Events.DomainErrorRaised>();
            List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
            notifiable.Handle += (notification, token) =>
            {
                errors.AddRange(notification.Errors);
                return Task.CompletedTask;
            };
            var mediator = mockMediator.Create(notifiable);
            var productSaga = new ProductSaga(repository, list.AsQueryable(), mediator);
            Domain.Commands.CreateProductCommand command = new Domain.Commands.CreateProductCommand(1000, "teste", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse> { }
            });
            var task = productSaga.Handle(command, default);
            task.Wait();
            command = new Domain.Commands.CreateProductCommand(1000, "teste2", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse> { }
            });
            task = productSaga.Handle(command, default);
            task.Wait();
            mock.Context().Verify(item => item.Add(It.IsAny<Core.Product>()), Times.Once());

            Assert.True(list.Count.Equals(1));
            
            Assert.True(errors.Count(a => a.Key == "sku:duplicated").Equals(1));
        }

        [Fact]
        public void When_the_updateproductcommand_with_a_valid_product_is_provided_than_the_original_product_is_overrided()
        {
            var mockMediator = new Mock.MediatorHandlerMock();
            var mock = new test.Mock.RepositoryMock();
            var list = new List<Core.Product>();
            var repository = mock.Create(list);
            var notifiable = new Notifiable<Domain.Events.DomainErrorRaised>();
            List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
            notifiable.Handle += (notification, token) =>
            {
                errors.AddRange(notification.Errors);
                return Task.CompletedTask;
            };
            var mediator = mockMediator.Create(notifiable);
            var productSaga = new ProductSaga(repository, list.AsQueryable(), mediator);
            Domain.Commands.CreateProductCommand command = new Domain.Commands.CreateProductCommand(1000, "teste", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse> 
                { 
                    new Core.Warehouse
                    {
                        Sku = 1000,
                        Locality = "teste",
                        Quantity = 1,
                        Type = "teste 1"
                    }
                }
            });
            var task = productSaga.Handle(command, default);
            task.Wait();
            var updateCommand = new Domain.Commands.UpdateProductCommand(1000, "teste atualizado", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse> { }
            });
            task = productSaga.Handle(updateCommand, default);
            task.Wait();
            mock.Context().Verify(item => item.Add(It.IsAny<Core.Product>()), Times.Once());
            mock.Context().Verify(item => item.Update(It.IsAny<Core.Product>()), Times.Once());
            Assert.True(list.Count.Equals(1));
            Assert.True(errors.Count().Equals(0));
            Assert.True(list.First().Name == "teste atualizado");
        }

        [Fact]
        public async Task When_the_createproductcommand_with_a_product_with_all_werahouses_quatities_are_zero_than_the_product_ismarketable_should_be_false()
        {
            var mockMediator = new Mock.MediatorHandlerMock();
            var mock = new Mock.RepositoryMock();
            var list = new List<Core.Product>();
            var repository = mock.Create(list);
            var notifiable = new Notifiable<Domain.Events.DomainErrorRaised>();
            List<KeyValuePair<string, string>> errors = new List<KeyValuePair<string, string>>();
            notifiable.Handle += (notification, token) =>
            {
                errors.AddRange(notification.Errors);
                return Task.CompletedTask;
            };
            var mediator = mockMediator.Create(notifiable);
            var productSaga = new ProductSaga(repository, list.AsQueryable(), mediator);
            Domain.Commands.CreateProductCommand command = new Domain.Commands.CreateProductCommand(1000, "teste", new Core.Inventory
            {
                Quantity = 0,
                Warehouses = new List<Core.Warehouse>
                {
                    new Core.Warehouse
                    {
                        Sku = 1000,
                        Locality = "teste",
                        Quantity = 0,
                        Type = "teste 1"
                    }
                }
            });
            var task = await productSaga.Handle(command, default);
            ProductQuery productQuery = new ProductQuery(list.AsQueryable(), null);
            var product = list.First(f => f.Sku == 1000);
            product.CalculateInventory();
            Assert.False(product.IsMarketable);
        }
    }
}
