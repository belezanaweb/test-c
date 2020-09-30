using BelezaWeb.Domain.Model;
using MediatR;
using System.Collections.Generic;

namespace BelezaWeb.Domain.Models
{
    public class InventoryInput : IRequest<string>
    {
        private int quantity { get; set; }

        public List<Warehouse> warehouses { get; set; }
    }
}
