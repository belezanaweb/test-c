using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.DTOs;

namespace Belezanaweb.Application.Products.Commands
{
    public abstract class BaseProductCommand : RequestBase<Response>
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryDTO Inventory { get; set; }
    }
}
