using Desafio.Domain.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Interfaces
{
    public interface IProductComandsHandler
    {
        CommandResult Create(ProductCreateCommand productCreate, List<WarehouseCreateCommand> warehouseCommandList);
        CommandResult Update(ProductUpdateCommand productUpdate, List<WarehouseCreateCommand> warehouseCommandList);
        CommandResult Delete(ProductDeleteCommand productDelete);
    }
}
