using System.Collections.Generic;
using System.Linq;

namespace DTO
{
    /// <summary>
    /// DTO for Inventory
    /// </summary>
    public class InventoryDTO
    {
        #region Properties

        /// <summary>
        /// Quantity
        /// </summary>     
        public int Quantity => Warehouses.Sum(i => i.Quantity);

        /// <summary>
        /// A list of Warehouses
        /// </summary>
        public IList<WarehouseDTO> Warehouses { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryDTO()
        {
            Warehouses = new List<WarehouseDTO>();
        }

        #endregion
    }
}
