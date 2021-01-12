using GrupoBoticarioTeste.Business.Interfaces.Repositories;
using GrupoBoticarioTeste.Business.Interfaces.Services;
using GrupoBoticarioTeste.Business.Models;
using GrupoBoticarioTeste.Business.Models.Validations;
using GrupoBoticarioTeste.Business.ViewModels;
using System.Collections.Generic;

namespace GrupoBoticarioTeste.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _warehouseRepository;

        public ProductService(
            IProductRepository perfilRepository,
            IWarehouseRepository warehouseRepository,
            INotificadorService notificador) : base(notificador)
        {
            _productRepository = perfilRepository;
            _warehouseRepository = warehouseRepository;
        }

        public bool Add(ProductViewModel productViewModel)
        {
            Product product = new Product
            {
                Sku = productViewModel.Sku,
                Name = productViewModel.Name
            };

            List<Warehouse> warehouse = new List<Warehouse>();

            foreach (var dados in productViewModel.Warehouses)
            {
                Warehouse warehouseViewModel = new Warehouse
                {
                    Locality = dados.Locality,
                    ProductId = product.Sku,
                    Quantity = dados.Quantity,
                    Type = dados.Type
                };

                if (!ExecutarValidacao(new WarehouseValidation(), warehouseViewModel)) return false;
                warehouse.Add(warehouseViewModel);
            }

            if (!ExecutarValidacao(new ProductValidation(), product)) return false;

            if (_productRepository.BuscarProdutoPorSku(product.Sku) != null)
            {
                Notificar("Já existe um produto com este Sku informado.");
                return false;
            }

            

            _productRepository.Adicionar(product);
            _warehouseRepository.AddWarehouse(warehouse);

            return true;
        }

        public bool Change(int sku, ChangeViewModel changeViewModel)
        {
            Warehouse warehouse = new Warehouse();

            if (_productRepository.BuscarProdutoPorSku(sku) == null)
            {
                Notificar("Não existe um produto com este Sku informado.");
                return false;
            }

            Product product = new Product
            {
                Name = changeViewModel.Name,
                Sku = sku
            };

            foreach (var dados in changeViewModel.Warehouses)
            {
                warehouse = new Warehouse
                {
                    Locality = dados.Locality,
                    ProductId = sku,
                    Quantity = dados.Quantity,
                    Type = dados.Type
                };
            }

            _productRepository.Atualizar(product);
            _warehouseRepository.ChangeWarehouse(sku, warehouse);

            return true;
        }

        public SearchProductViewModel SearchById(int sku)
        {
            var product = _productRepository.ListProdutoPorSku(sku);

            if (product == null)
            {
                Notificar("Não existe um produto com este Sku informado.");
                return null;
            }

            return product;
        }

        public bool Remove(int sku)
        {
            var product = _productRepository.BuscarProdutoPorSku(sku);

            if (product == null)
            {
                Notificar("Não existe um produto com este Sku informado.");
                return false;
            }

            _productRepository.Remover(product);
            return true;
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
            _warehouseRepository?.Dispose();
        }
    }
}
