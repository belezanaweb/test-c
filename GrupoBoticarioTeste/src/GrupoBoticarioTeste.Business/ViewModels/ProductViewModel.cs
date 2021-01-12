using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.ViewModels
{
    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public ICollection<WarehouseViewModel> Warehouses { get; set; }
    }
}
