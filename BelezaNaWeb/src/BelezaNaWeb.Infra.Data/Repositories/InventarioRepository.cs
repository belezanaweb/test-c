using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Infra.Data.Context;
using Emprestae.Infra.Data.Repositories;

namespace BelezaNaWeb.Infra.Data.Repositories
{
    public class InventarioRepository : RepositoryBase<Inventario>, IInventarioRepository
    {
        public InventarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
