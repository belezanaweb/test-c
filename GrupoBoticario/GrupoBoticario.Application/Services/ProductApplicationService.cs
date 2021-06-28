using GrupoBoticario.Application.Interfaces;
using GrupoBoticario.Domain.Interfaces;
using GrupoBoticario.Domain.Models.Product;
using GrupoBoticario.Domain.Payload.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBoticario.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductApplicationService> _logger;

        public ProductApplicationService(
            IProductService productService,
            ILogger<ProductApplicationService> logger)
        {
            _productService = productService;
            _logger = logger;

        }
        public async Task AddProduct(IEnumerable<ProductSavePayload> payload)
        {
            if (payload is null is true)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            AssineCadastroRegrasPayload(payload);

            await _productService.AddProduct(payload);
        }
        public async Task UpdateProduct(IEnumerable<ProductUpdatePayload> payloads)
        {
            if (payloads is null is true)
            {
                throw new ArgumentNullException(nameof(payloads));
            }

            AssineAtualizacaoRegrasPayload(payloads);

            await _productService.UpdateProduct(payloads);
        }
        public async Task DeleteProduct(long sku)
        {
            await _productService.DeleteProduct(sku);
        }
        public async Task<ProductViewModel> ObterPorId(long sku)
        {
            return await _productService.ObterPorId(sku);
        }
        public async Task<IEnumerable<ProductViewModel>> ObterTodos()
        {
            return await _productService.ObterTodos();
        }
        private void AssineCadastroRegrasPayload(IEnumerable<ProductSavePayload> payload)
        {
            payload
                .ToList().ForEach(x =>
                {
                    x.AssineSeguro();

                    x.Inventory.AssineSeguro();

                    x.Inventory.WareHouses.ToList().ForEach(x => x.AssineSeguro());
                });
        }

        private void AssineAtualizacaoRegrasPayload(IEnumerable<ProductUpdatePayload> payload)
        {
            payload
                .ToList().ForEach(x =>
                {
                    x.AssineSeguro();

                    x.Inventory.AssineSeguro();

                    x.Inventory.WareHouses.ToList().ForEach(x => x.AssineSeguro());
                });
        }
    }
}
