using Domain.Dtos;
using Domain.Entites;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.AutoMapper
{
    public class Mapper
    {
        #region ToDTO

        public static ProductCreateDto ToCreateDto(Product product)
        {
            return new ProductCreateDto
            {
                Name = product.Name,
                Inventory = new InventoryDto
                {
                    Warehouses = product.Inventory.Warehouses.Select(w => new WarehouseDto
                    {
                        Locality = w.Locality,
                        Quantity = w.Quantity,
                        Type = w.Type
                    }).ToList()
                }
            };
        }

        public static List<ProductListDto> ToListDto(List<Product> products)
        {
            return products.Select(p => new ProductListDto
            {
                IsMarketable = p.IsMarketable,
                Sku = p.Id,
                Name = p.Name,
                Inventory = new InventoryListDto
                {
                    Warehouses = p.Inventory.Warehouses.Select(i => new WarehouseDto
                    {
                        Locality = i.Locality,
                        Quantity = i.Quantity,
                        Type = i.Type
                    }).ToList()
                }
            }).ToList();
        }

        public static ProductListDto ToDtolist(Product product)
        {
            if (product != null)
            {
                return new ProductListDto
                {
                    IsMarketable = product.IsMarketable,
                    Name = product.Name,
                    Sku = product.Id,
                    Inventory = new InventoryListDto
                    {
                        Warehouses = product.Inventory.Warehouses.Select(i => new WarehouseDto
                        {
                            Locality = i.Locality,
                            Quantity = i.Quantity,
                            Type = i.Type
                        }).ToList()
                    }
                };
            }
            return null;
        }

        public static ProductUpdateDto ToUpdateDto(Product product)
        {
            return new ProductUpdateDto
            {
                Sku = product.Id,
                Name = product.Name,
                Inventory = new InventoryDto
                {
                    Warehouses = product.Inventory.Warehouses.Select(w => new WarehouseDto
                    {
                        Locality = w.Locality,
                        Quantity = w.Quantity,
                        Type = w.Type
                    }).ToList()
                }
            };
        }

        #endregion

        #region ToDomain

        public static Product ToCreateDomain(ProductCreateDto productCreateDto)
        {
            return new Product
            {
                Name = productCreateDto.Name,
                Inventory = new Inventory
                {
                    Warehouses = productCreateDto.Inventory.Warehouses.Select(i => new Warehouse
                    {
                        Locality = i.Locality,
                        Quantity = i.Quantity,
                        Type = i.Type
                    }).ToList()
                }
            };
        }

        public static Product ToUpdateDomain(ProductUpdateDto productUpdateDto)
        {
            return new Product
            {
                Name = productUpdateDto.Name,
                Id = productUpdateDto.Sku,
                Inventory = new Inventory
                {
                    Warehouses = productUpdateDto.Inventory.Warehouses.Select(i => new Warehouse
                    {
                        Locality = i.Locality,
                        Quantity = i.Quantity,
                        Type = i.Type
                    }).ToList()
                }
            };
        }

        #endregion
    }
}
