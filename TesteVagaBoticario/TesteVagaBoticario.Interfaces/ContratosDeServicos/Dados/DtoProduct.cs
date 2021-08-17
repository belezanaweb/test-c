using System;
using System.Collections.Generic;
using System.Text;

namespace TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados
{
    public class DtoProduct
    {
        public int Sku { get; set; }

        public string Name { get; set; }

        public DtoInventory Inventory { get; set; }

        public bool IsMarketable { get; set; } // => Inventory?.Quantity > 0;
    }
}
