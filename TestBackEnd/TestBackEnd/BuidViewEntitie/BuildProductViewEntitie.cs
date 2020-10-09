using BackendTest.Entities;
using BackendTest.ViewEntities;
using System.Collections.Generic;

namespace ProjetctWebApiTestBackEnd.BuidViewEntitie
{
    public class BuildProductViewEntities
    {
        public IList<ViewProduct> Products { get; private set;  }

        public BuildProductViewEntities(Product product)
        {
            Products = new List<ViewProduct>();
            MappingProductToViewProduct(product);
        }

        public BuildProductViewEntities(List<Product> products)
        {
            Products = new List<ViewProduct>();
            MappingListProductToListViewProduct(products);
        }

        private void MappingProductToViewProduct(Product product)
        {

            var viewProduct = new ViewProduct()
            {
                Sku = product.Sku,
                IsMarketable = product.IsMarketable,
                Name = product.Name
            };

            viewProduct.Inventory = new ViewInventory()
            {
                Quantity = product.Inventory.Quantity
            };

            viewProduct.Inventory.WareHouses = new List<ViewWareHouse>();

            foreach (var waireHouse in product.Inventory.WareHouses)
            {
                viewProduct.Inventory.WareHouses.Add(new ViewWareHouse()
                                                     {
                                                        Locality = waireHouse.Locality,
                                                        Quantity = waireHouse.Quantity,
                                                        Type = waireHouse.Type
                                                     }

                                                    );
            }

            Products.Add(viewProduct);
        }

        private void MappingListProductToListViewProduct(List<Product> products)
        {
            foreach (var product in products)
            {
                MappingProductToViewProduct(product);
            }
        }
    }
}
