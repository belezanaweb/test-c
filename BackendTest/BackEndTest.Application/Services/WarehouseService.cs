using AutoMapper;
using BackEndTest.Application.DTOs;
using BackEndTest.Application.Interfaces;
using BackEndTest.Domain.Entities;
using BackEndTest.Domain.Interfaces;

namespace BackEndTest.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IMapper _mapper;
        private IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository ??
                throw new ArgumentNullException(nameof(warehouseRepository));
            _mapper = mapper;
        }

        public async Task<bool> CreateWarehouses(List<WarehouseDTO> warehousesDTOs, int productSku)
        {
            var warehousesEntity = _mapper.Map<List<Warehouse>>(warehousesDTOs);
            return await _warehouseRepository.CreateWarehousesAsync(warehousesEntity, productSku);
        }

        public async Task<List<WarehouseDTO>> GetWarehousesByProductSku(int productSku)
        {
            List<Warehouse> WarehouseEntity = await _warehouseRepository.GetWarehousesByProductSkuAsync(productSku);
            return _mapper.Map<List<WarehouseDTO>>(WarehouseEntity);
        }

        public async Task<bool> RemoveWarehousesByProductSku(int productSku)
        {
            return await _warehouseRepository.RemoveWarehousesByProductSkuAsync(productSku);
        }

        public async Task<bool> UpdateWarehousesBySku(List<WarehouseDTO> warehousesDTOs)
        {
            List<Warehouse> warehouseEntity = _mapper.Map<List<Warehouse>>(warehousesDTOs);
            return await _warehouseRepository.UpdateWarehousesBySkuAsync(warehouseEntity);
        }
    }
}
