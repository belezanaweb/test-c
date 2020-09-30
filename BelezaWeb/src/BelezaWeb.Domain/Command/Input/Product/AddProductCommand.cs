using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using MediatR;

namespace BelezaWeb.Domain.Command.Input.AddProduct
{
    public class AddProductCommand : IRequest<Response>
    {
        public int sku { get; set; }
        public string name { get; set; }
        public InventoryInput inventory { get; set; }
    }
}
