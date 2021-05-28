using Inventory.Core.Notification;
using MediatR;
using Moq;
using NetHacksPack.Core.Extensions.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.test.Mock
{
    class RepositoryMock
    {
        private Mock<Core.Data.IStorageRepository> mock = new Mock<Core.Data.IStorageRepository>();
        public Core.Data.IStorageRepository Create(List<Core.Product> products)
        {
            mock.Setup((config) => config.Add(It.IsAny<Core.Product>())).Returns<Core.Product>((product) =>
            {
                products.Add(product);
                return new NetHacksPack.Core.Result<bool>(true);
            });
            mock.Setup((config) => config.Update(It.IsAny<Core.Product>())).Returns<Core.Product>((product) =>
            {
                var index = products.FindIndex((p) => p.Sku == product.Sku);
                products[index] = product;
                return new NetHacksPack.Core.Result<bool>(true);
            });
            return mock.Object;
        }

        public Mock<Core.Data.IStorageRepository> Context()
        {
            return mock;
        }
    }

    class MediatorHandlerMock
    {
        private Mock<IMediatorHandler> mock = new Mock<IMediatorHandler>();
        public IMediatorHandler Create<T>(INotificationHandler<T> notificationHandler)
            where T : INotification
        {

            mock.Setup((config) => config.PublishEvent(It.IsAny<Domain.Events.DomainErrorRaised>()))
                .Returns<Domain.Events.DomainErrorRaised>((@event) =>
                {
                    T notification = (T)(object)@event;
                    notificationHandler.Handle(notification, default);
                    return Task.CompletedTask;
                });
            return mock.Object;
        }

        public Mock<IMediatorHandler> Context()
        {
            return mock;
        }
    }
}
