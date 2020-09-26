using BelezaNaWeb.Domain.Dtos;
using BelezaNaWeb.Domain.Enums;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Commands
{
    public sealed class CreateProductCommand : CommandBase<CreateProductResult>
    {
        #region Public Properties

        public long Sku { get; set;  }
        public string Name { get; set; }
        public IEnumerable<CreateProductWarehouseCommand> Warehouses { get; set; }

        #endregion
    }

    public sealed class CreateProductWarehouseCommand
    {
        #region Public Properties

        public int Quantity { get; set; }
        public string Locality { get; set; }
        public WarehouseTypes Type { get; set; }

        #endregion
    }

    public class CreateProductResult : ProductDto
    {
        #region Public Properties

        #endregion
    }
}
