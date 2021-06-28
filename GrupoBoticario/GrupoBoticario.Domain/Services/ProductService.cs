using GrupoBoticario.Domain.Entity.Product;
using GrupoBoticario.Domain.Enums;
using GrupoBoticario.Domain.Extensions;
using GrupoBoticario.Domain.Interfaces;
using GrupoBoticario.Domain.IRepositories;
using GrupoBoticario.Domain.Models.Product;
using GrupoBoticario.Domain.Payload.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IWareHouseRepository _wareHouseRepository;

        public ProductService(
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository,
            IWareHouseRepository wareHouseRepository,
            ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _wareHouseRepository = wareHouseRepository;
            _logger = logger;
        }

        public async Task AddProduct(IEnumerable<ProductSavePayload> payloads)
        {
            try
            {
                _logger.LogInformation($"Inserindo a entidade {nameof(ProductEntity)}.");

                if (payloads is null) 
                {
                    throw new InvalidOperationException($"O {nameof(payloads)} não pode ser nulo.");
                }

                if (payloads.Any() is false)
                {
                    throw new InvalidOperationException($"O {nameof(payloads)} está vazio inválido.");
                }

                var products = ObterListaParaCadastroProduct(payloads);

                await _productRepository.AddRangeAsync(products);

                _logger.LogInformation($"Finalizando a insersão  da entidade {nameof(ProductEntity)}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errro ao inserir a entidade{nameof(ProductEntity)}. Message: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProduct(IEnumerable<ProductUpdatePayload> payloads)
        {
            try
            {
                _logger.LogInformation($"Atualizando a entidade {nameof(ProductEntity)}.");

                VerificaSkuDuplicado(payloads);

                var listaProductConsultado = await ObterProducts(payloads);

                var productsAtualizados = ObterProdutAtualizado(listaProductConsultado, payloads);

                await _productRepository.UpdateRangeAsync(productsAtualizados);

                _logger.LogInformation($"Finalizando a atualização  da entidade {nameof(ProductEntity)}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errro ao atualizar a entidade{nameof(ProductEntity)}. Message: {ex.Message}");
                throw;
            }
        }
        public async Task DeleteProduct(long sku)
        {
            try
            {
                _logger.LogInformation($"Excluindo a entidade {nameof(ProductEntity)}.");

                var productConsultado = await _productRepository.ObterPorId(sku);

                if (productConsultado is null)
                {
                    throw new InvalidOperationException($"O código sku {sku} inválido para exclusão.");
                }

                await _productRepository.DeleteAsync(productConsultado);

                _logger.LogInformation($"Finalizando a atualização  da entidade {nameof(ProductEntity)}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errro ao atualizar a entidade{nameof(ProductEntity)}. Message: {ex.Message}");
                throw;
            }
        }
        public async Task<ProductViewModel> ObterPorId(long sku)
        {
            var product = await _productRepository.ObterPorId(sku);

            if (product is null)
                return null;

            return new ProductViewModel
            {
                Name = product?.Name,
                Sku = product.Sku,
                IsMarketable = product.Inventory.WareHouses.Count() > 0,
                Inventory = new InventoryViewModel
                {
                    Quantity = ObterQuantifWareHouses(product?.Inventory?.WareHouses),
                    WareHouses = ObterWareHousesViewModel(product?.Inventory?.WareHouses)
                }
            };
        }

        public async Task<IEnumerable<ProductViewModel>> ObterTodos()
        {
            var products = await _productRepository.ObterTodos();

            if (products.Any() is false)
                return null;

            return products?.
                Select(product => new ProductViewModel
                {
                    Name = product?.Name,
                    Sku = product.Sku,
                    IsMarketable = product.Inventory.WareHouses.Count() > 0,
                    Inventory = new InventoryViewModel
                    {
                        Quantity = ObterQuantifWareHouses(product?.Inventory?.WareHouses),
                        WareHouses = ObterWareHousesViewModel(product?.Inventory?.WareHouses)
                    }
                });
        }
        private async Task<IEnumerable<ProductEntity>> ObterProducts(IEnumerable<ProductUpdatePayload> payloads)
        {
            var retorno = new List<ProductEntity>();

            var task = payloads.Select(async x =>
            {
                var productConsultado = await _productRepository.ObterPorId(x.Sku);

                if (productConsultado is null is false)
                    retorno.Add(productConsultado);
            });

            await Task.WhenAll(task);

            if (retorno.Any() is false)
            {
                throw new InvalidOperationException("Não existe sku para ser atualizado.");
            }

            return retorno;
        }

        private IEnumerable<ProductEntity> ObterListaParaCadastroProduct(IEnumerable<ProductSavePayload> payloads)
        {
            return payloads
                .Select(payload => new ProductEntity
                {                     
                    Name = payload?.Name,
                    CreateAt = DateTime.UtcNow,
                    Inventory = ObterInventory(payload, DateTime.UtcNow)
                })
                .ToList();
        }

        private void VerificaSkuDuplicado(IEnumerable<ProductUpdatePayload> payloads)
        {
            var existeSkuDuplicado = payloads.
                ObterSkuDuplicados();

            if (existeSkuDuplicado is true)
            {
                throw new InvalidOperationException("Existe sku duplicado.");
            }
        }

        private IEnumerable<WareHouseViewModel> ObterWareHousesViewModel(IEnumerable<WareHouseEntity> wareHouses)
        {
            return wareHouses?
                .Distinct()
                .Select(x => new WareHouseViewModel
                {
                    Locality = x.Locality,
                    Quantity = x.Quantity,
                    Type = x.TypeWareHouseId
                });
        }

        private int ObterQuantifWareHouses(IEnumerable<WareHouseEntity> wareHouses)
        {
            return wareHouses
                .Distinct()
                .Sum(x => x.Quantity);
        }

        private InventoryEntity ObterInventory(ProductPayload payload, DateTime? dateCreate = null, DateTime? dateUpdate = null)
        {
            if (payload is null)
            {
                return null;
            }

            if (payload.Inventory is null)
            {
                return null;
            }

            return new InventoryEntity
            {
                CreateAt = dateCreate,
                UpdateAt = dateUpdate,
                WareHouses = ObterWareHouses(payload?.Inventory?.WareHouses, dateCreate)
            };
        }
        private IEnumerable<WareHouseEntity> ObterWareHouses(IEnumerable<WareHousePayload> wareHouses, DateTime? dateCreate = null, DateTime? dateUpdate = null)
        {
            return wareHouses?
                .Select(w => new WareHouseEntity
                {
                    CreateAt = dateCreate,
                    UpdateAt = dateUpdate,
                    Locality = w.Locality,
                    Quantity = w.Quantity,
                    TypeWareHouseId = w.Type
                })
                .ToList();
        }

        private IEnumerable<ProductEntity> ObterProdutAtualizado(IEnumerable<ProductEntity> listProductEntityConsultado, IEnumerable<ProductUpdatePayload> payloads)
        {
            var retorno = new List<ProductEntity>();

            foreach (var productEntityConsultado in listProductEntityConsultado)
            {
                var payload = payloads
                    .FirstOrDefault(x => x.Sku == productEntityConsultado.Sku);

                if (payload is null is true)
                    continue;

                productEntityConsultado.Name = payload?.Name;
                productEntityConsultado.UpdateAt = DateTime.UtcNow;
                productEntityConsultado.Inventory.UpdateAt = DateTime.UtcNow;
                productEntityConsultado.Inventory = ObterInventoryParaAtualizacao(productEntityConsultado.Inventory, payload?.Inventory);

                retorno.Add(productEntityConsultado);
            }

            if (retorno.Any() is false)
            {
                throw new InvalidOperationException("Não existe sku para ser atualizado.");
            }

            return retorno;
        }

        private InventoryEntity ObterInventoryParaAtualizacao(InventoryEntity inventory, InventoryPayload payload)
        {
            inventory.WareHouses = ObterWareHouses(payload?.WareHouses);
            return inventory;
        }
    }
}
