using AspNetCore.IQueryable.Extensions.Filter;
using AutoMapper;
using Boticario.ApplicationService.IServices;
using Boticario.Domain.Handlers;
using Boticario.Domain.Models;
using Boticario.Domain.Search;
using Boticario.Domain.Validations;
using Boticario.Domain.ViewModels;
using Boticario.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario.ApplicationService.Services
{
    public class ProductsService : ApplicationServiceBase<Products>, IProductsService
    {
  
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        
        /** CONTRUCTOR USED BY UNIT TEST. **/
        public ProductsService(ILogger logger, IMapper mapper, INotification notification, bool unitTest=true) : base(logger, notification)
        {
            _mapper = mapper;
            _productsRepository = new ProductsRepository();
        }


        /**CONSTRUCTOR USED BY DEPENDENCE INJECTION**/
        public ProductsService(IProductsRepository productsRepository, ILogger<Products> logger, IMapper mapper, INotification notification) : base(logger, notification)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;            
        }



        /// <summary>
        /// Retorna uma lista de produtos de acordo o filtro na queryString da requisição
        /// </summary>
        /// <param name="filterQuery">Do tipo ProductSearch, contém todos os filtros aceitos na queryString</param>
        /// <returns></returns>
        public async Task<IList<Products>> Search(ProductSearch filterQuery)
        {
            var filter =  _productsRepository.GetCollectionAsync().AsQueryable().FilterExpression(filterQuery);

            var products = await _productsRepository.FindAsync(filter, filterQuery.Limit, filterQuery.Page);

            return products;
        }

        /// <summary>
        /// Retorna um produto referente o sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public async Task<Products> Get(int sku)
        {
            var product = await _productsRepository.FindOneAsync(x => x.Sku == sku);
            if (product == null) {
                _notifications.AddError("Produto inexistente.");
                return null;
            }

            product.Inventory?.TotalizeQuantity();
            product.VerifyIsMarketable();
            

            return product;
        }

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Products</returns>
        public async Task<IEnumerable<Products>> Get()
        {
            var products = await _productsRepository.FindAsync();

            return products;
        }


        /// <summary>
        /// Insert one product
        /// </summary>
        /// <param name="product">the product data</param>
        /// <returns>Products</returns>
        public async Task<Products> Save(ProductViewModel product)
        {
            var productEntity = _mapper.Map<Products>(product);

            var productSku = await _productsRepository.FindOneAsync(x => x.Sku == product.Sku);
            if (productSku != null) {
                _notifications.AddError($"Já existe um produto com o sku: {productSku.Sku}");
                return null;
            }


            productEntity.Inventory?.TotalizeQuantity();
            productEntity.VerifyIsMarketable();
            

            //Executa validações
            if (!this.ModelIsValid(productEntity, new ProductsSaveValidator()))
                return null;


            await _productsRepository.CreateAsync(productEntity);

            //Mensagen no console e no ApplicationInsights caso tenha um subscription configurado no appSetings.Development.json
            _logger.LogInformation(new EventId(1,"PROD"), $"Produto inserido: {productEntity.Name}");

            return productEntity;
        }


        /// <summary>
        /// Atuliza o produto referente ao sku passado
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Products> Update(int sku, ProductUpdateViewModel product)
        {
            var productDb = await _productsRepository.FindOneAsync(x => x.Sku == sku);
            
            if (productDb == null) {
                _notifications.AddError($"Produto inexistente!");
                return null;
            }

            var productEntity = _mapper.Map<Products>(product);
            productEntity.SetId(productDb.Id);
            productEntity.SetSku(productDb.Sku);

            productEntity.Inventory?.TotalizeQuantity();
            productEntity.VerifyIsMarketable();

            await _productsRepository.UpdateAsync(productEntity);

            _logger.LogInformation(new EventId(1, "PROD"), $"Produto modificado: {productDb.Name} json:{productEntity.ToJson()}");

            return productEntity;
        }


        /// <summary>
        /// Exclui o produto referente o sku
        /// </summary>
        /// <param name="sku">sku do produto</param>
        /// <returns></returns>
        public async Task<Products> Delete(int sku)
        {
            var productSku = await _productsRepository.FindOneAsync(x => x.Sku == sku);

            if (productSku == null) {
                _notifications.AddError($"Produto inexistente!");
                return null;
            }

           
            await _productsRepository.DeleteByIdAsync(productSku.Id);

            return productSku;
        }


    }
}
