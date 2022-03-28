using BackendTest.Domain.Commands.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace BackendTest.Domain.Commands.Requests
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public long Sku { get; set; }
        public string Name { get; set; }
        public InventoryUpdateRequest Inventory { get; set; }

        public void AtribuirSku(long sku)
        {
            Sku = sku;
        }
    }

    public class InventoryUpdateRequest
    {
        public IEnumerable<WarehouseUpdateRequest> Warehouses { get; set; }
    }

    public class WarehouseUpdateRequest
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
