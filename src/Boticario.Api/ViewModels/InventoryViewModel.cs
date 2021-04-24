using System.Collections.Generic;

namespace Boticario.Api.ViewModels
{
    public class InventoryViewModel
    {
        #region Attributes

        public uint quantity { get; set; }

        public List<WarehouseViewModel> warehouses { get; set; }

        #endregion
    }
}