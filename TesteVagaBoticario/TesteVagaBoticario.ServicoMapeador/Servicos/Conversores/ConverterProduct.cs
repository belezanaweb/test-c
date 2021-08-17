using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados;
using TesteVagaBoticario.Negocio;
using TesteVagaBoticario.ServicoMapeador.Infraestrutura;

namespace TesteVagaBoticario.ServicoMapeador.Servicos.Conversores
{
    public class ConverterProduct : IConverter<DtoProduct, Product>
    {
        public DtoProduct ConverterToDto(Product objeto)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Product, DtoProduct>();
                config.CreateMap<Inventory, DtoInventory>();
                config.CreateMap<Warehouse, DtoWarehouse>();
            });

            return Mapper.Map<Product, DtoProduct>(objeto);
        }

        public Product ConverterToObject(DtoProduct dto)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<DtoProduct, Product>();
                config.CreateMap<DtoInventory, Inventory>();
                config.CreateMap<DtoWarehouse, Warehouse>();
            });

            var produto = Mapper.Map<DtoProduct, Product>(dto);

            CarregaIdentificadores(produto);

            return produto;
        }

        public Product ConverterToUpdate(Product objeto, DtoProduct dto)
        {
            var objetoAlterado = ConverterToObject(dto);

            objeto.Name = objetoAlterado.Name;
            objeto.Inventory.Warehouses = objetoAlterado.Inventory.Warehouses;

            return objeto;
        }

        private void CarregaIdentificadores(Product produto)
        {

            produto.Id = ObtenhaGuid(produto.Id);
            produto.Inventory.Id = ObtenhaGuid(produto.Inventory.Id);
            produto.Inventory.IdProduct = produto.Id;

            produto.Inventory.Warehouses.ForEach(item =>
            {
                item.Id = ObtenhaGuid(item.Id);
                item.IdInventory = produto.Inventory.Id;
            });
        }

        private Guid ObtenhaGuid(Guid idObjeto)
        {
            if (idObjeto == Guid.Empty)
            {
                return Guid.NewGuid();
            }

            return idObjeto;
        }
    }
}
