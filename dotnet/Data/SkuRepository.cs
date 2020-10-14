using System.Linq;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;

namespace Data
{
    public class SkuRepository : IStockKeepingUnitRepository
    {
        ICollection<StockKeepingUnit> dados = new List<StockKeepingUnit>();

        public StockKeepingUnit Add(StockKeepingUnit sku)
        {
            if (dados.Any(x => x.sku == sku.sku))
                throw new Exception("Dois produtos são considerados iguais se os seus skus forem iguais");

            dados.Add(sku);

            return sku;
        }

        public void Delete(int sku)
        {
            var item = dados.FirstOrDefault(x => x.sku == sku);
            if (item != null)
                dados.Remove(item);
            else
                throw new Exception($"SKU {sku} não encontrado.");
        }

        public IEnumerable<StockKeepingUnit> GetAll()
        {
            return dados;
        }

        public StockKeepingUnit GetBySku(int sku)
        {
            return dados.FirstOrDefault(x => x.sku == sku);
        }

        public StockKeepingUnit Update(StockKeepingUnit sku)
        {
            var item = dados.FirstOrDefault(x => x.sku == sku.sku);
            if (item == null)
                throw new Exception($"SKU {sku.sku} não encontrado.");

            dados.Remove(item);
            dados.Add(sku);

            return sku;
        }



    }
}
