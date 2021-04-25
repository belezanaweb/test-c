using System.Collections.Generic;

namespace Boticario.Api.ViewModels
{
    public class InventoryViewModel
    {
        #region Properties

        public uint Quantity { get; set; }

        public List<WarehouseViewModel> Warehouses { get; set; }

        #endregion
    }
}