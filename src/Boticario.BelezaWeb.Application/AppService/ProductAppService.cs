using AutoMapper;
using Boticario.BelezaWeb.Application.Interfaces;
using Boticario.BelezaWeb.Application.ViewModels.Product;
using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Boticario.BelezaWeb.Domain.Interfaces.Services;
using Boticario.BelezaWeb.Domain.Results;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Application.AppService
{
	public class ProductAppService : IProductAppService
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;
		private readonly IProductRepository _productRepository;

		public ProductAppService(
			IMapper mapper,
			IProductService productService,
			IProductRepository productRepository)
		{
			_mapper = mapper;
			_productService = productService;
			_productRepository = productRepository;
		}

		public async Task<ProductViewModel> FindBySku(int sku)
		{
			var product = await _productRepository
				.FindBySku(sku);

			return _mapper.Map<ProductViewModel>(product);
		}

		public async Task<Result<ProductViewModel>> Add(ProductViewModel viewModel)
		{
			var entity = _mapper.Map<Product>(viewModel);
			var result = await _productService.Add(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<ProductViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<ProductViewModel>> Edit(ProductViewModel viewModel)
		{
			var entity = _mapper.Map<Product>(viewModel);
			var result = await _productService.Edit(entity);

			if (!result.Success)
				viewModel.Errors = result.Object;

			return Result<ProductViewModel>.Create(result.Success, result.Message, viewModel);
		}

		public async Task<Result<ProductViewModel>> Delete(int id)
		{
			var entity = await _productRepository.Find(id);

			if (entity is null)
				return Result<ProductViewModel>.Create(false, ProductMessages.NotFound);

			_productRepository.Delete(entity);
			await _productRepository.Save();
			return Result<ProductViewModel>.Create(true, ProductMessages.SuccessDelete);
		}
	}
}
