using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IStockKeepingUnitRepository
    {
        IEnumerable<StockKeepingUnit> GetAll();
        StockKeepingUnit GetBySku(int sku);


        StockKeepingUnit Add(StockKeepingUnit sku);
        StockKeepingUnit Update(StockKeepingUnit sku);
        void Delete(int sku);
    }
}
