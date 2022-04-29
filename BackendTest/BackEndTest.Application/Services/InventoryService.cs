using AutoMapper;
using BackEndTest.Application.DTOs;
using BackEndTest.Application.Interfaces;
using BackEndTest.Domain.Entities;
using BackEndTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTest.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private IMapper _mapper;
        private IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ??
                throw new ArgumentNullException(nameof(inventoryRepository));
            _mapper = mapper;
        }

        public async Task<bool> CreateInventory(InventoryDTO inventoryDTO, int productSku)
        {
            var inventoryEntity = _mapper.Map<Inventory>(inventoryDTO);
            return await _inventoryRepository.CreateInventoryAsync(inventoryEntity, productSku);
        }

        public async Task<InventoryDTO> GetInventoryByProductSku(int productSku)
        {
            Inventory inventoryEntity = await _inventoryRepository.GetInventoryByProductSkuAsync(productSku);
            return _mapper.Map<InventoryDTO>(inventoryEntity);
        }

        public async Task<bool> RemoveInventoryByProductSku(int productSku)
        {
            return await _inventoryRepository.RemoveInventoryByProductSkuAsync(productSku);
        }

        public async Task<bool> UpdateInventoryByProductSku(InventoryDTO inventoryDTO)
        {
            var inventoryEntity = _mapper.Map<Inventory>(inventoryDTO);
            return await _inventoryRepository.UpdateInventoryByProductSkuAsync(inventoryEntity);
        }
    }
}
