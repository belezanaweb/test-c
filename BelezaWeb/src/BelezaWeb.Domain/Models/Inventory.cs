using MediatR;
using System.Collections.Generic;

namespace BelezaWeb.Domain.Model
{
    public class Inventory : IRequest<string>
    {
        public int quantity { get; set; }
        public List<Warehouse> warehouses { get; set; }
    }
}
