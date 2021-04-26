using DemoTest.Domain.Entities;
using DemoTest.Domain.Repository.Interfaces;

namespace DemoTest.Infra.Repository
{
    public class InventarioRepository : BaseRepository<Inventario>, IInventarioRepository
    {
        public InventarioRepository(ContextRepository context) : base(context) { }
    }
}
