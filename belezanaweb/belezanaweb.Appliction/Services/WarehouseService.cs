using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Domain.Interfaces.Services;

namespace belezanaweb.Application.Services
{
    public class WarehouseService : ServiceBase<Warehouse>, IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
