using AutoMapper;
using BelezaNaWeb.Application.ViewModel;
using BelezaNaWeb.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Inventario , opt => opt.MapFrom(src => PreencherDeWarehouseParaInventario(src.Inventory.Warehouses)));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForPath(dest => dest.Inventory.Warehouses, opt => opt.MapFrom(src => PreencherDeInventarioParaWarehouse(src.Inventario)));
        }

        private IEnumerable<Inventario> PreencherDeWarehouseParaInventario(IEnumerable<WarehousesViewModel> warehouses)
        {
            var inventario = new List<Inventario>();

            foreach (var movimento in warehouses)
            {
                var novoMovimento = new Inventario()
                {
                    Localidade = movimento.Locality,
                    Quantidade = movimento.Quantity,
                    Tipo = movimento.Type
                };

                inventario.Add(novoMovimento);
            }

            return inventario;
        }

        private IEnumerable<WarehousesViewModel> PreencherDeInventarioParaWarehouse(IEnumerable<Inventario> inventario)
        {
            var warehousesView = new List<WarehousesViewModel>();

            foreach (var movimento in inventario)
            {
                var novoMovimento = new WarehousesViewModel()
                {
                    Locality = movimento.Localidade,
                    Quantity = movimento.Quantidade,
                    Type = movimento.Tipo
                };

                warehousesView.Add(novoMovimento);
            }

            return warehousesView;
        }
    }
}
