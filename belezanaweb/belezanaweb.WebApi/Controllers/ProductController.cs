using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using belezanaweb.Domain.Entities;
using belezanaweb.Domain.Interfaces.Services;
using belezanaweb.Domain.ViewModels;
using belezanaweb.Domain.ViewModels.Product;
using belezanaweb.Infra.Data.Transactions;
using belezanaweb.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace belezanaweb.WebApi.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IUnitOfWork unit, IMapper mapper)
        {
            _productService = productService;
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet("/api/v1/products")]
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAllAsync());
        }

        [HttpGet("/api/v1/products/{sku}")]
        public async Task<ResultViewModel> Get(int sku)
        {
            var result = new ResultViewModel();
            
            Product model = await _productService.FindBySkuAsync(sku);

            if (model == null)
            {
                result.Message = "Produto não encontrado";
            }
            else
            {
                result.Success = true;
                result.Message = "Produto encontrado";
                result.Data = _mapper.Map<ProductViewModel>(model);
            }
            return result;
        }

        [HttpPost("api/v1/products")]
        public async Task<ResultViewModel> Post([FromBody] ProductViewModel product)
        {
            var result = new ResultViewModel();

            if (product == null)
            {
                result.Message = "Erro ao cadastrar produto, favor confira se os parâmetros informados estão corretos";
                return result;
            }

            if (await _productService.FindBySkuAsync(product.Sku) != null)
            {
                result.Message = "Produto já existente em nosso sistema";
                return result;
            }

            if (ModelState.IsValid)
            {
                Product model = _mapper.Map<Product>(product);
                await _productService.AddAsync(model);
                _unit.Commit();
                result.Success = true;
                result.Message = "Produto cadastrado com sucesso";
                result.Data = _mapper.Map<ProductViewModel>(model);
            }
            else
            {
                result.Message = "Erro ao cadastrar produto";
                result.Data = this.ModelStateErrors(ModelState);
            }
            return result;
        }

        [HttpPut("api/v1/products")]
        public async Task<ResultViewModel> Put([FromBody] ProductViewModel product)
        {
            var result = new ResultViewModel();

            if (product == null)
            {
                result.Message = "Erro ao atualizar produto, favor confira se os parâmetros informados estão corretos";
                return result;
            }

            if (ModelState.IsValid)
            {
                bool exists = await _productService.FindBySkuAsync(product.Sku) != null;

                if (exists)
                {
                    Product model = _mapper.Map<Product>(product);
                    await _productService.UpdateAsync(model);
                    _unit.Commit();

                    result.Success = true;
                    result.Message = "Produto atualizado com sucesso";
                    result.Data = _mapper.Map<ProductViewModel>(model);
                    return result;
                }
                else
                {
                    result.Message = "Produto não localizado";
                    return result;
                }
            }
            result.Message = "Erro ao atualizar produto";
            result.Data = this.ModelStateErrors(ModelState);
            return result;
        }


        [HttpDelete("api/v1/products/{sku}")]
        public async Task<ResultViewModel> Delete(int sku)
        {
            var result = new ResultViewModel();
            var product = await _productService.FindBySkuAsync(sku);

            if (product == null)
            {
                result.Message = "Produto não encontrado";
                return result;
            }

            await _productService.DeleteAsync(product);
            _unit.Commit();
            result.Success = true;
            result.Message = "Produto deletado";
            return result;
        }
    }
}
