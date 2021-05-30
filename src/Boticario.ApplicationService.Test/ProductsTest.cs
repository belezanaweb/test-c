using Boticario.ApplicationService.IServices;
using Boticario.ApplicationService.Services;
using Boticario.Domain;
using Boticario.Domain.Models;
using Boticario.Domain.Search;
using Boticario.Domain.ViewModels;
using Boticario.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boticario.ApplicationService.Test
{


    [TestClass]
    public class ProductsTest : TestBase
    {
        ProductsService _productsService;
        IProductsRepository _productsRepository;




        public ProductsTest()
        {
            //Inicializa();
        }

        public void Inicializa( )
        {
            InicializaMock();
            _productsService = new ProductsService(_logger, _mapper, _notification, true );

            _productsRepository = new ProductsRepository();
        }

        public ProductViewModel MountProduct()
        {
            var productView = new ProductViewModel();

            productView.Sku =  new Random().Next(1,10000);
            productView.Name = $"Produto Test. unit {DateTime.Now}";
            productView.Inventory = new InventoryViewModel()
            {
                Warehouses = new List<WarehouseViewModel>()
                {
                    new WarehouseViewModel()
                    {
                        Locality = "SP",
                        Quantity = 0,
                        Type = "ECOMMERCE"
                    },
                   
                    new WarehouseViewModel()
                    {
                        Locality = "Moema",
                        Quantity = 15,
                        Type = "PHYSICAL_STORE"
                    }
                   
                }
                
            };

            return productView;
        }


        /****************** BUSCAR ********************/
       

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_Save()
        {
            Inicializa();
            var productView = MountProduct();
           

            var productSaved = await _productsService.Save(productView);


            Assert.AreNotEqual(null, productSaved, _productsService.ReturnValidationsToString());
        }

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_Not_Save_Name_Empty()
        {
            Inicializa();
            var productView = MountProduct();
            productView.Name = "";

            var productSaved = await _productsService.Save(productView);


            Assert.AreEqual(null, productSaved, $"Produto salvo indevidamente {_productsService.ReturnValidationsToString()}");
        }

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_Not_Save_Sku_Zero()
        {
            Inicializa();
            var productView = MountProduct();
            productView.Sku = 0;

            var productSaved = await _productsService.Save(productView);


            Assert.AreEqual(null, productSaved, $"Produto salvo indevidamente {_productsService.ReturnValidationsToString()}");
        }

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_List()
        {
            Inicializa();

            //VErificando se a base de dados ytem produtos
            var productsSaved = await _productsRepository.FindAsync();


            //Se a base de dados estiver vazia, insiro um produto, para posteriormente testar a listagem
            if (productsSaved.Count == 0)
            {
                var productView = MountProduct();
                var productEntity = _mapper.Map<Products>(productView);

                await _productsRepository.CreateAsync(productEntity);
            }


            //testando a listagem
            var productList = await _productsService.Get();


            Assert.AreEqual(true, productList.Count() >0, _productsService.ReturnValidationsToString());
        }

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_GetBy_Sku()
        {
            Inicializa();

            //VErificando se a base de dados ytem produtos
            var productsSaved = (await _productsRepository.FindAsync()).FirstOrDefault();


            //Se a base de dados estiver vazia, insiro um produto, para posteriormente testar a listagem
            if (productsSaved == null)
            {
                var productView = MountProduct();
                var productEntity = _mapper.Map<Products>(productView);

                await _productsRepository.CreateAsync(productEntity);

                productsSaved = productEntity;
            }


            //testando a listagem
            var product = await _productsService.Get(productsSaved.Sku);


            Assert.AreNotEqual(null, product, _productsService.ReturnValidationsToString());
        }

        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_GetBy_Filter()
        {
            Inicializa();

            //VErificando se a base de dados ytem produtos
            var productsSaved = (await _productsRepository.FindAsync()).FirstOrDefault();

            
            //Se a base de dados estiver vazia, insiro um produto, para posteriormente testar a listagem
            if (productsSaved == null)
            {
                var productView = MountProduct();
                var productEntity = _mapper.Map<Products>(productView);

                await _productsRepository.CreateAsync(productEntity);

                productsSaved = productEntity;
            }


            //var filter = new ProductSearch() { Name = productsSaved.Name.Substring(0, 3) };
            var filter = new ProductSearch() { Page = 0, Limit=2 };

            //testando a listagem
            var products = await _productsService.Search(filter);

            Thread.Sleep(100000);


            Assert.AreEqual(true, products != null && products.Count() > 0, _productsService.ReturnValidationsToString());
        }


        


        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_Update()
        {
            Inicializa();

            //verificando se a base de dados tem produtos que foram inseridos peo teste
            var productsSaved = await _productsRepository.FindOneAsync(x=> x.Name.ToUpper().Contains("TEST. UNIT"));


            //Se não tiver produto que foi inserido pelo test unit
            if (productsSaved == null)
            {
                var productView = MountProduct();
                var productEntity = _mapper.Map<Products>(productView);

                await _productsRepository.CreateAsync(productEntity);

                productsSaved = productEntity;
            }

            var productViewAtualizado = _mapper.Map<ProductUpdateViewModel>(productsSaved);
            productViewAtualizado.Name = $"Produto atualizado Test. unit {DateTime.Now}";

            //testando a listagem
            var product = await _productsService.Update(productsSaved.Sku, productViewAtualizado);


            Assert.AreNotEqual(null, product, _productsService.ReturnValidationsToString());
        }



        [TestCategory("Products")]
        [TestMethod]
        public async Task Should_Delete()
        {
            Inicializa();

            //verificando se a base de dados tem produtos que foram inseridos peo teste
            var productsSaved = await _productsRepository.FindOneAsync(x => x.Name.ToUpper().Contains("TEST. UNIT"));


            //Se não tiver produto que foi inserido pelo test unit
            if (productsSaved == null)
            {
                var productView = MountProduct();
                var productEntity = _mapper.Map<Products>(productView);

                await _productsRepository.CreateAsync(productEntity);

                productsSaved = productEntity;
            }

            
            
            var productDeleted = await _productsService.Delete(productsSaved.Sku);

            //verifica se existe ainda na base
            var productDb = await _productsRepository.FindByIdAsync(productDeleted.Id);

            Assert.AreEqual(null, productDb, _productsService.ReturnValidationsToString());
        }




    }


}
