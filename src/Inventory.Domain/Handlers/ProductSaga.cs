using Inventory.Core;
using Inventory.Core.Data;
using Inventory.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using NetHacksPack.Core.Extensions.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Domain.Handlers
{
    public class ProductSaga 
        : MediatR.IRequestHandler<CreateProductCommand, bool>,
          MediatR.IRequestHandler<UpdateProductCommand, bool>,
          MediatR.IRequestHandler<RemoveProductCommand, bool>
    {
        private readonly IStorageRepository storageRepository;
        private readonly IQueryable<Product> products;
        private readonly IMediatorHandler mediatorHandler;

        public ProductSaga(IStorageRepository storageRepository, IQueryable<Product> products, IMediatorHandler mediatorHandler)
        {
            this.storageRepository = storageRepository;
            this.products = products;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(fd => fd.Sku == request.Sku);
            request = new CreateProductCommand(request, product);
            if (!request.EhValido())
            {
                await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(request.Notifications));
                return false;
            }
            var result = storageRepository.Add((Product)request);
            if (result.Data)
            {
                await mediatorHandler.PublishEvent(new Events.ProductCreated((Product)request));
                return true;
            }
            await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(result.Errors.Select(s => new KeyValuePair<string, string>("storage:errors", s))));
            return false;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = products.Where(w => w.Sku == request.Sku);
            request = new UpdateProductCommand(request, product);
            if (!request.EhValido())
            {
                await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(request.Notifications));
                return false;
            }
            var data = ((Product)request);
            var result = storageRepository.Update(data);
            if (result.Data)
            {
                await mediatorHandler.PublishEvent(new Events.ProductUpdated((Core.Product)request));
                return true;
            }
            await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(result.Errors.Select(s => new KeyValuePair<string, string>("storage:errors", s))));
            return false;
        }

        public async Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = products.Include(p => p.Inventory).ThenInclude(p => p.Warehouses).FirstOrDefault(fd => fd.Sku == request.Sku);
            request = new RemoveProductCommand(request, product);
            if (!request.EhValido())
            {
                await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(request.Notifications));
                return false;
            }
            var result = storageRepository.Remove(product);
            if (result.Data)
            {
                await mediatorHandler.PublishEvent(new Events.ProductRemoved(request.Sku));
                return true;
            }
            await mediatorHandler.PublishEvent(new Events.DomainErrorRaised(result.Errors.Select(s => new KeyValuePair<string, string>("storage:errors", s))));
            return false;
        }
    }
}
