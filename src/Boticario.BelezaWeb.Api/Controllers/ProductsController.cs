using Boticario.BelezaWeb.Application.Interfaces;
using Boticario.BelezaWeb.Application.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : BaseController
	{
		private readonly IProductAppService _productAppService;

		public ProductsController(IProductAppService productAppService)
		{
			_productAppService = productAppService;
		}

		[HttpGet("{sku}")]
		public async Task<IActionResult> Get(int? sku)
		{
			if (!sku.HasValue)
				return BadRequest();

			var result = await _productAppService.FindBySku(sku.Value);
			return result is null
				? NotFound()
				: Json(result);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
		{
			var result = await _productAppService.Add(productViewModel);
			return result.Success
				? Json(result.Success, result.Message)
				: Json(result.Success, result.Object.Errors);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] ProductViewModel productViewModel)
		{
			var result = await _productAppService.Edit(productViewModel);
			return result.Success
				? Json(result.Success, result.Message)
				: Json(result.Success, result.Object.Errors);
		}

		[HttpDelete("{sku}")]
		public async Task<IActionResult> Delete(int? sku)
		{
			if (!sku.HasValue)
				return BadRequest();

			var result = await _productAppService.Delete(sku.Value);
			return result.Success
				? Json(result.Success, result.Message)
				: Json(result.Success, result.Object.Errors);
		}
	}
}
