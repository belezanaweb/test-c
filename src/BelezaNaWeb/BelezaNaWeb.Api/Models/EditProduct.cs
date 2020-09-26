using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Api.Models
{
    public class EditProduct
    {
        #region Public Properties

        public string Name { get; set; }
        public EditProductInventory Inventory { get; set; }

        #endregion
    }

    public class EditProductInventory
    {
        public IEnumerable<EditProductWarehouse> Warehouses { get; set; }
    }

    public class EditProductWarehouse
    {

    }
}
