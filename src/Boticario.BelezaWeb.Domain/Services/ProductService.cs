using Boticario.BelezaWeb.Domain.Catalog.Messages;
using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Boticario.BelezaWeb.Domain.Interfaces.Services;
using Boticario.BelezaWeb.Domain.Notifications;
using Boticario.BelezaWeb.Domain.Results;
using Boticario.BelezaWeb.Domain.Validators;
using Boticario.BelezaWeb.Domain.Validators.ProductValidators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Domain.Services
{
	public class ProductService : Service<Product>, IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<Result<IEnumerable<string>>> Add(Product product)
		{
			var resultValidation = Validate(product);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			product.Inventory.ProductSku = product.Sku;
			_productRepository.Add(product);
			await _productRepository.Save();
			return Result<IEnumerable<string>>.Create(true, ProductMessages.SuccessRegister);
		}

		public async Task<Result<IEnumerable<string>>> Edit(Product product)
		{
			var resultValidation = Validate(product, isUpdate: true);
			if (resultValidation.Errors.Count > 0)
				return Result<IEnumerable<string>>.Create(false, resultValidation.Errors);

			var existingProduct = await _productRepository.FindBySku(product.Sku);
			if (existingProduct is null)
				return Result<IEnumerable<string>>.Create(false, ProductMessages.NotFound);

			existingProduct.Name = product.Name;
			existingProduct.Inventory = product.Inventory;

			_productRepository.Update(existingProduct);
			await _productRepository.Save();
			return Result<IEnumerable<string>>.Create(true, ProductMessages.SuccessEdit);
		}

		public override Notification Validate(Product product, bool isUpdate = false)
		{
			IValidator validator;
			if (isUpdate)
				validator = new ProductUpdateValidator(product);
			else
				validator = new ProductValidator(product, _productRepository);

			EventPublisher.RaiseNotificationEvent += HandleNotificationEvent;
			_ = validator.Validate();
			return Notifier;
		}
	}
}
