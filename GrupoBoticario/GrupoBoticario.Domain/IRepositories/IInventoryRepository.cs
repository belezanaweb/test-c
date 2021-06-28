using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.IRepositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoBoticario.Domain.IRepositories
{
    public interface IInventoryRepository : IRepositoryBase<InventoryEntity>
    {
    }
}
