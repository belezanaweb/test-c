using GrupoBoticarioTeste.Business.Interfaces.Services;
using GrupoBoticarioTeste.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GrupoBoticarioTeste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;

        public ProductController(INotificadorService notificador, IProductService productService) : base(notificador)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<ProductViewModel> Adicionar(ProductViewModel product)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _productService.Add(product);
            return CustomResponse(product);
        }

        [HttpPut("{sku:int}")]
        public ActionResult<ProductViewModel> Change(int sku, ChangeViewModel changeViewModel)
        {
            return CustomResponse(_productService.Change(sku, changeViewModel));
        }

        [HttpGet("{sku:int}")]
        public ActionResult<SearchProductViewModel> SearchById(int sku)
        {
            var productViewModel = _productService.SearchById(sku);

            return CustomResponse(productViewModel);
        }

        [HttpDelete("{sku:int}")]
        public IActionResult Delete(int sku)
        {
            return CustomResponse(_productService.Remove(sku));
        }
    }
}