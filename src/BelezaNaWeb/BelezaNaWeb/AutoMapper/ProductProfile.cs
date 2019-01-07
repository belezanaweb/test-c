using System;
using AutoMapper;
using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Domain.Products.Enums;
using BelezaNaWeb.Domain.Products.ValueObjects;
using BelezaNaWeb.Models;

namespace BelezaNaWeb.AutoMapper
{
	public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ConvertUsing<CustomProductConverter>();
        }
    }

    public class CustomProductConverter : ITypeConverter<ProductViewModel, Product>
    {
        public Product Convert(ProductViewModel source, Product destination, ResolutionContext context)
        {
            var inventory = new ProductInventory();


            foreach(var warehouse in source.Inventory.Warehouses)
            {
                var type = context.Mapper.Map<string, ProductInventoryWarehouseType>(warehouse.type);
                inventory.AddOrUpdate(warehouse.Locality, type, warehouse.quantity);
            }

            return new Product(source.Sku, source.Name, inventory);
        }
    }

    public class CustomProductInventoryWarehouseTypeConverter : ITypeConverter<string, ProductInventoryWarehouseType>
    {
        public ProductInventoryWarehouseType Convert(string source, ProductInventoryWarehouseType destination, ResolutionContext context)
        {
            source = source.ToUpper();

            if (source == "ECOMMERCE")
                return ProductInventoryWarehouseType.ECOMMERCE;
            else if (source == "PHYSICAL_STORE")
                return ProductInventoryWarehouseType.PHYSICAL_STORE;
            else
                throw new ArgumentException("Tipo de warehouse náo reconhecido.");
        }
    }
}
