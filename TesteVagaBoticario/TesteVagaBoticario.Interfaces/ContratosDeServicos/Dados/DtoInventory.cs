using System;
using System.Collections.Generic;
using System.Text;

namespace TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados
{
    public class DtoInventory
    {
        public DtoInventory()
        {
            warehouses = new List<DtoWarehouse>();
        }

        public List<DtoWarehouse> warehouses { get; set; }

        public int quantity { get; set;  } // => Warehouses?.Sum(w => w.Quantity) ?? 0;
    }
}
