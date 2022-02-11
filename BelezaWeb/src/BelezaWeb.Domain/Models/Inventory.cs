using MediatR;
using System.Collections.Generic;

namespace BelezaWeb.Domain.Models
{
    public class Inventory : IRequest<string>
    {
        public int Quantity { get; set; }
        public List<Warehouse> Warehouses { get; set; }
    }
}
