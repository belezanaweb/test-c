using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.ViewModels
{
    public class ChangeViewModel
    {
        public string Name { get; set; }
        public ICollection<WarehouseViewModel> Warehouses { get; set; }
    }
}
