using System.Collections.Generic;
using NUnit.Framework;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Tests
{
    public class ProductRepositoryTest
    {
        [Test]
        public void CreateProductTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            Product? createdProduct = repo.GetProduct(sku);

            Assert.IsNotNull(createdProduct);
        }

        [Test]
        public void UpdateProductBySkuTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            string newName = "M�scara Capilar Si�ge Expert Regenerac�o P�s Qu�mica 250g Vers�o 2";

            product.Name = newName;

            repo.UpdateProduct(sku, product);

            var updatedProduct = repo.GetProduct(sku);

            Assert.IsTrue(newName.Equals(updatedProduct.Name));
        }

        [Test]
        public void GetProductBySkuTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            var createdProduct = repo.GetProduct(sku);

            Assert.IsNotNull(createdProduct);
        }

        [Test]
        public void DeleteProductBySkuTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            repo.DeleteProduct(sku);

            var deletedProduct = repo.GetProduct(sku);

            Assert.IsNull(deletedProduct);
        }

        [Test]
        public void InventoryQuantityTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            var createdProduct = repo.GetProduct(sku);

            Assert.AreEqual(createdProduct.Inventory.Quantity, 15);
        }

        [Test]
        public void ProductIsMarketableTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 12,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 3,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            var createdProduct = repo.GetProduct(sku);

            Assert.IsTrue(createdProduct.IsMarketable);
        }

        [Test]
        public void ProductIsNotMarketableTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 0,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 0,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            var createdProduct = repo.GetProduct(sku);

            Assert.IsFalse(createdProduct.IsMarketable);
        }

        [Test]
        public void DuplicateProductTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 0,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 0,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            var duplicateProduct = new Product
            {
                Sku = sku,
                Name = "M�scara Capilar Si�ge Expert Regenerac�o P�s Qu�mica 250g Vers�o 2",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "PORTO ALEGRE",
                            Quantity = 6,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        },
                        new ProductWarehouse {
                            Locality = "RS",
                            Quantity = 17,
                            Type = WarehouseTypes.ECOMMERCE
                        }
                    }
                }
            };

            var ex = Assert.Throws<ValidationException>(() => repo.CreateProduct(duplicateProduct));

            Assert.AreEqual(ex.ValidationMessage, "A product with the informed SKU already exists in the repository.");
        }

        [Test]
        public void UpdateProductBySkuWithDifferentSkusTest()
        {
            IProductRepository repo = new ProductRepositoryMock();

            int sku = 43264;

            var product = new Product
            {
                Sku = sku,
                Name = "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g",
                Inventory = new ProductInventory
                {
                    Warehouses = new List<ProductWarehouse> {
                        new ProductWarehouse {
                            Locality = "SP",
                            Quantity = 0,
                            Type = WarehouseTypes.ECOMMERCE
                        },
                        new ProductWarehouse {
                            Locality = "MOEMA",
                            Quantity = 0,
                            Type = WarehouseTypes.PHYSICAL_STORE
                        }
                    }
                }
            };

            repo.CreateProduct(product);

            product.Sku = 54375;
            product.Name = "M�scara Capilar Si�ge Expert Regenerac�o P�s Qu�mica 250g Vers�o 2";

            var ex = Assert.Throws<ValidationException>(() => repo.UpdateProduct(sku, product));

            Assert.AreEqual(ex.ValidationMessage, "The SKU present in the request is different from the product SKU.");
        }
    }
}