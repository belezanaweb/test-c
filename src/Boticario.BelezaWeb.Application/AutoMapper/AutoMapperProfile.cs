using AutoMapper;
using Boticario.BelezaWeb.Application.ViewModels.Product;
using Boticario.BelezaWeb.Domain.Entities;

namespace Boticario.BelezaWeb.Application.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Product, ProductViewModel>().ReverseMap();
			CreateMap<Inventory, InventoryViewModel>().ReverseMap();
			CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();
		}
	}
}
