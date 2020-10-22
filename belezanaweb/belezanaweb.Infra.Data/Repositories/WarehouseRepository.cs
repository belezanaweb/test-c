using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Repositories;
using belezanaweb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace belezanaweb.Infra.Data.Repositories
{
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(BelezanawebContext context)
            : base(context)
        {

        }
    }
}
