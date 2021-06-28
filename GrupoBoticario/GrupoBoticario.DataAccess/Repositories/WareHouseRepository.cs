using GrupoBoticario.DataAccess.Repositories.Generic;
using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBoticario.DataAccess.Repositories
{
    public class WareHouseRepository : RepositoryBase<WareHouseEntity>, IWareHouseRepository
    {
        public WareHouseRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
