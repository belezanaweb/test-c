using MediatR;
using System.Collections.Generic;

namespace BelezaWeb.Domain.Models
{
    public class InventoryInput : IRequest<string>
    {
        private int Quantity { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}
