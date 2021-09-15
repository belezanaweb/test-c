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
    public class WarehouseService : BaseService, IWarehouseService
    {
        private readonly ITelemetryService _telemetryService;
        private readonly INotificationService _notificationService;
        private readonly IWarehouseRepository _warehouseRespository;

        public WarehouseService(
            ITelemetryService telemetryService,
            IWarehouseRepository warehouseRespository,
            INotificationService notificationService)
        {
            _warehouseRespository = warehouseRespository;
            _notificationService = notificationService;
            _telemetryService = telemetryService;
        }

        public async Task<bool> Create(Warehouse warehouse)
        {
            try
            {
                if (!WarehouseValidate(warehouse))
                {
                    return false;
                }

                if (await _warehouseRespository.Add(warehouse) == 0)
                {
                    _notificationService.Add(WarehouseResource.DbCreateUnexpectedError);
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                var msg = string.Format(WarehouseResource.ExceptionUnexpectedly, "criar", warehouse.ProdutoSku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return false;
            }
        }

        public async Task<bool> Delete(int sku)
        {
            try
            {
                return await _warehouseRespository.Delete(sku);
            }
            catch (Exception e)
            {
                var msg = string.Format(WarehouseResource.ExceptionUnexpectedly, "excluir", sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return false;
            }
        }

        public async Task<IEnumerable<Warehouse>> Get(int sku)
        {
            try
            {
                return await _warehouseRespository.Get(sku);
            }
            catch (Exception e)
            {
                var msg = string.Format(WarehouseResource.ExceptionUnexpectedly, "consultar", sku);
                _telemetryService.TrackException(e, msg);
                _notificationService.Add(msg);

                return null;
            }
        }

        private bool WarehouseValidate(Warehouse warehouse)
        {
            if (!IsValid(new WarehouseValidation().Validate(warehouse)))
            {
                _notificationService.Add(ValidationResult.Errors.ToArray());
                return false;
            }

            return true;
        }
    }
}
