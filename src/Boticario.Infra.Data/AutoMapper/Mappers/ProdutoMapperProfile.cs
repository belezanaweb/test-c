using Boticario.Core.Domains;
using Boticario.Core.Model.DTOs.Produto;
using Boticario.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boticario.Infra.Data.AutoMapper.Mappers
{
    public class ProdutoMapperProfile : ProfileBase
    {
        public ProdutoMapperProfile()
        {
            CreateMap<TabelaProduto, Produto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(x => x.Estoque, opt => opt.MapFrom(src => src.TabelaEstoque)).ReverseMap();

            CreateMap<TabelaEstoque, Estoque>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
            .ForMember(x => x.Tipo, opt => opt.MapFrom(src => src.Tipo))
            .ForMember(x => x.Local, opt => opt.MapFrom(src => src.Local)).ReverseMap();

            CreateMap<TabelaProduto, ProdutoDTO>()
            .ForMember(x => x.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Nome))
            .ForMember(x => x.Inventory, opt => opt.MapFrom(src => new InventarioDTO
            {
                Warehouses = src.TabelaEstoque.Select(x => new EstoqueDTO
                {
                    Locality = x.Local,
                    Quantity = x.Quantidade,
                    Type = x.Tipo
                }).ToList()
            }));
        }
    }
}
