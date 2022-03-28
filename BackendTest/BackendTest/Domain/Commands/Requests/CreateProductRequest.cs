using BackendTest.Domain.Commands.Responses;
using MediatR;
using System.Collections.Generic;

namespace BackendTest.Domain.Commands.Requests
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryCreateRequest Inventory { get; set; }
    }

    public class InventoryCreateRequest
    {
        public IEnumerable<WarehouseCreateRequest> Warehouses { get; set; }
    }

    public class WarehouseCreateRequest
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
