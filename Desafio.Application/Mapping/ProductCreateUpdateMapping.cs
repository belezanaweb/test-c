using Desafio.Application.ViewModels.CreateUpdate;
using Desafio.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Application.Mapping
{
    public static class ProductCreateUpdateMapping
    {
        public static ProductCreateCommand GetProductCreateCommand(ProductCreateUpdateReadViewModel viewModel)
        {
            return new ProductCreateCommand(sku: viewModel.Sku, name: viewModel.Name);
        }

        public static ProductUpdateCommand GetProductUpdateCommand(ProductCreateUpdateReadViewModel viewModel)
        {
            return new ProductUpdateCommand(sku:viewModel.Sku, name: viewModel.Name);
        }

        public static ProductDeleteCommand GetProductDeleteCommand(int sku)
        {
            return new ProductDeleteCommand(sku: sku);
        }

        public static List<WarehouseCreateCommand> GetWarehouseList(ProductCreateUpdateReadViewModel viewModel)
        {
            return viewModel
                .Inventory
                .Warehouses
                .Select(x => new WarehouseCreateCommand(x.Locality, x.Quantity, x.Type))
                .ToList();
        }
    }
}
