using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class EditProductCommand : CommandBase<bool>
    {
        #region Public Properties
        
        public long Sku { get; set; }
        public string Name { get; set; }
        public IEnumerable<EditProductWarehouseCommand> Warehouses { get; set; }

        #endregion
    }

    public sealed class EditProductWarehouseCommand
    {
        #region Public Properties

        public int Quantity { get; set; }
        public string Locality { get; set; }
        public string Type { get; set; }

        #endregion
    }
}
