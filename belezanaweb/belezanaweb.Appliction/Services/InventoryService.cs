using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Domain.Interfaces.Services;

namespace belezanaweb.Application.Services
{
    public class InventoryService : ServiceBase<Inventory>, IInventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
