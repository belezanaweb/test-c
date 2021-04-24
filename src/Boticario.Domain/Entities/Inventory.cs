using System.Collections.Generic;

namespace Boticario.Domain.Entities
{
    public class Inventory
    {
        #region Attributes

        public uint Quantity { get; set; }

        public IList<Warehouse> Warehouses { get; set; }

        #endregion
    }
}