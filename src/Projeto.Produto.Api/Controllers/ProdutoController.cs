using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Domain.Interfaces;
using Projeto.Domain.Models;
using Projeto.Produtos.Api.Request;
using Projeto.Produtos.Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Produtos.Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoAppService;
        private readonly IMapper _mapper;

        public ProdutoController(
            IMapper mapper,
            INotificationService notificationService,
            IProdutoService produtoService)
            :base(notificationService)
        {
            _produtoAppService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ProdutoRequest request)
        {
            var produto = _mapper.Map<Produto>(request);
            var warehouse = _mapper.Map<IEnumerable<Warehouse>>(request.Inventory?.Warehouses);
            return Response(await _produtoAppService.Create(produto, warehouse).ConfigureAwait(false));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int sku, [FromBody] ProdutoRequest request)
        {
            var produto = _mapper.Map<Produto>(request);
            var warehouse = _mapper.Map<IEnumerable<Warehouse>>(request.Inventory?.Warehouses);
            return Response(await _produtoAppService.Update(sku, produto, warehouse).ConfigureAwait(false));
        }

        [HttpDelete("{sku}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int sku)
        {
            return Response(await _produtoAppService.Delete(sku).ConfigureAwait(false));
        }

        [HttpGet("{sku}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int sku)
        {
            var produtoInventory = await _produtoAppService.CalculteInventory(sku).ConfigureAwait(false);
            if (produtoInventory == null || produtoInventory?.Sku == 0)
            {
                return ResponseNotFound();
            }

            var response = new ProdutoViewModel()
            {
                Sku = produtoInventory.Sku,
                Nome = produtoInventory.Nome,
                IsMarketable = produtoInventory.IsMarketable,
                Inventory = new InventoryViewModel() 
                { 
                    Quantity = produtoInventory.Quantity, 
                    Warehouses = _mapper.Map<IEnumerable<WarehouseViewModel>>(produtoInventory.Warehouses) 
                }
            };
            return Response(response);
        }
    }
}
