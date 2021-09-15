using Projeto.Domain.Interfaces;
using Projeto.Domain.Models;
using Projeto.Domain.Repositories;
using Projeto.Domain.Resources;
using Projeto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Domain.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly ITelemetryService _telemetryService;
        private readonly INotificationService _notificationService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IWarehouseService _warehouseService;

        public ProdutoService(
            ITelemetryService telemetryService,
            IProdutoRepository produtoRepository,
            INotificationService notificationService,
            IWarehouseService warehouseService)
        {
            _telemetryService = telemetryService;
            _produtoRepository = produtoRepository;
            _notificationService = notificationService;
            _warehouseService = warehouseService;
        }

        public async Task<bool> Create(Produto produto, IEnumerable<Warehouse> warehouses)
        {
            try
            {
                if (!ProdutoValidate(produto))
                {
                    return false;
                }

                if (await _produtoRepository.Exist(produto.Sku))
                {
                    _notificationService.Add(ProdutoResource.SkuInUse);
                    return false;
                }

                if (await _produtoRepository.Add(produto) == 0)
                {
                    _notificationService.Add(ProdutoResource.DbCreateUnexpectedError);
                    return false;
                }

                return await WarehouseCreate(produto.Sku, warehouses);
            }
            catch (Exception e)
            {
                var msg = string.Format(ProdutoResource.ExceptionUnexpectedly, "criar", produto.Sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return false;
            }
        }

        public async Task<bool> Delete(int sku)
        {
            try
            {
                await _warehouseService.Delete(sku);
                if (_notificationService.HasNotification) return false;

                if (!await _produtoRepository.Delete(sku))
                {
                    _notificationService.Add(ProdutoResource.DbCreateUnexpectedError);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                var msg = string.Format(ProdutoResource.ExceptionUnexpectedly, "excluir", sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return false;
            }
        }

        public async Task<bool> Update(int sku, Produto produto, IEnumerable<Warehouse> warehouses)
        {
            try
            {
                if (sku != produto.Sku)
                {
                    _notificationService.Add(ProdutoResource.SkuIncorret);
                    return false;
                }

                if (!ProdutoValidate(produto))
                {
                    return false;
                }

                if (!await _produtoRepository.Exist(produto.Sku))
                {
                    _notificationService.Add(ProdutoResource.SkuNotFound);
                    return false;
                }

                await _warehouseService.Delete(produto.Sku);
                if (_notificationService.HasNotification) return false;

                if (await _produtoRepository.Update(produto) == 0)
                {
                    _notificationService.Add(ProdutoResource.DbCreateUnexpectedError);
                    return false;
                }

                return await WarehouseCreate(produto.Sku, warehouses);
            }
            catch (Exception e)
            {
                var msg = string.Format(ProdutoResource.ExceptionUnexpectedly, "atualizar", produto.Sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return false;
            }
        }

        public async Task<ProdutoInventory> CalculteInventory(int sku)
        {
            try
            {
                var produto = await _produtoRepository.Get(sku);
                if (produto == null)
                {
                    _notificationService.Add(ProdutoResource.SkuNotFound);
                    return new ProdutoInventory();
                }

                var warehouse = await _warehouseService.Get(sku);
                if (_notificationService.HasNotification) return new ProdutoInventory();

                var produtoInventory = new ProdutoInventory()
                {
                    Nome = produto.Nome,
                    Sku = produto.Sku,
                    Warehouses = warehouse
                };

                return produtoInventory;
            }
            catch (Exception e)
            {
                var msg = string.Format(ProdutoResource.ExceptionUnexpectedly, "consultar", sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return new ProdutoInventory();
            }
        }

        private async Task<bool> WarehouseCreate(int sku, IEnumerable<Warehouse> warehouses)
        {
            foreach (var warehouse in warehouses)
            {
                warehouse.ProdutoSku = sku;
                await _warehouseService.Create(warehouse);
                if (_notificationService.HasNotification) return false;
            }

            return true;
        }

        private bool ProdutoValidate(Produto produto)
        {
            if (!IsValid(new ProdutoValidation().Validate(produto)))
            {
                _notificationService.Add(ValidationResult.Errors.ToArray());
                return false;
            }

            return true;
        }
    }
}
