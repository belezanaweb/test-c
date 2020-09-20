using BelezaNaWeb.Api.Controllers;
using BelezaNaWeb.Api.Model;
using BelezaNaWeb.Application;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Infra.Data.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

public class ApiTests
{
    readonly ProductController _productController;

    public ApiTests()
    {
        var productRepository = new ProductRepository();
        var productApplication = new ProductApplication(productRepository);
        _productController = new ProductController(productApplication);
    }

    [Fact]
    public void GetAll_Ok()
    {
        var result = _productController.GetAll();
        var actual = (result.Result as OkObjectResult).StatusCode;
        var expected = new OkResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetBySku_ValidSkuWithQuantity_Ok()
    {
        var product = new ProductModel
        {
            Sku = 77,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        _productController.Post(product);

        var result = _productController.Get(product.Sku);
        var newProduct = (result.Result as OkObjectResult).Value as Product;

        //Validating Sku
        var actual = newProduct.Sku;
        var expected = product.Sku;
        Assert.Equal(expected, actual);

        //Validating quantity rule
        var actualQuantity = newProduct.Inventory.Quantity;
        var expectedQuantity = 25;
        Assert.Equal(expectedQuantity, actualQuantity);

        //Validating quantity rule
        var actualMarketable = newProduct.IsMarketable;
        var expectedMarketable = true;
        Assert.Equal(expectedMarketable, actualMarketable);
    }

    [Fact]
    public void GetBySku_ValidSkuWithoutQuantity_Ok()
    {
        var product = new ProductModel
        {
            Sku = 778,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 0,
                        Type = "PHYSICAL_STORE"
                    }
                }
            }
        };
        _productController.Post(product);

        var result = _productController.Get(product.Sku);
        var newProduct = (result.Result as OkObjectResult).Value as Product;

        //Validating Sku
        var actual = newProduct.Sku;
        var expected = product.Sku;
        Assert.Equal(expected, actual);

        //Validating quantity rule
        var actualQuantity = newProduct.Inventory.Quantity;
        var expectedQuantity = 0;
        Assert.Equal(expectedQuantity, actualQuantity);

        //Validating quantity rule
        var actualMarketable = newProduct.IsMarketable;
        var expectedMarketable = false;
        Assert.Equal(expectedMarketable, actualMarketable);
    }

    [Fact]
    public void GetBySku_InvalidSku_Ok()
    {
        var sku = -9776;
        var result = _productController.Get(sku);
        var actual = (result.Result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateProduct_AllParamsCorrects_Ok()
    {
        var product = new ProductModel
        {
            Sku = 43264,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        var result = _productController.Post(product);

        var actualStatucCode = (result as OkObjectResult).StatusCode;
        var expectedStatusCode = new OkResult().StatusCode;
        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void CreateProduct_RepetedSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = 555,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        _productController.Post(product);
        var postResult = _productController.Post(product);

        var actualStatucCode = (postResult as BadRequestObjectResult).StatusCode;
        var expectedStatusCode = new BadRequestResult().StatusCode;
        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void CreateProduct_QuantityZero_Ok()
    {
        var product = new ProductModel
        {
            Sku = 432641,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 0,
                        Type = "PHYSICAL_STORE"
                    }
                }
            }
        };
        var postResult = _productController.Post(product);

        var actualStatucCode = (postResult as OkObjectResult).StatusCode;
        var expectedStatusCode = new OkResult().StatusCode;
        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void CreateProduct_InvalidSku_Error()
    {
        var product = new ProductModel
        {
            Sku = -4,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };

        var result = _productController.Post(product);
        var actual = (result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateProduct_WithoutSku_Error()
    {
        var product = new ProductModel
        {
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };

        var result = _productController.Post(product);
        var actual = (result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateProduct_WithoutName_Error()
    {
        var product = new ProductModel
        {
            Sku = 1,
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };

        var result = _productController.Post(product);
        var actual = (result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void UpdateProduct_AllParamsCorrects_Ok()
    {
        var product = new ProductModel
        {
            Sku = 222,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        _productController.Post(product);

        product.Name = "Kit Melbec";

        var result = _productController.Update(product);
        var actualStatucCode = (result as OkObjectResult).StatusCode;
        var expectedStatusCode = new OkResult().StatusCode;

        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void UpdateProduct_InvalidSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = -222,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };

        var result = _productController.Update(product);
        var actualStatucCode = (result as BadRequestObjectResult).StatusCode;
        var expectedStatusCode = new BadRequestResult().StatusCode;

        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void UpdateProduct_InexistentSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = 8222,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };

        var result = _productController.Update(product);
        var actualStatucCode = (result as BadRequestObjectResult).StatusCode;
        var expectedStatusCode = new BadRequestResult().StatusCode;

        Assert.Equal(expectedStatusCode, actualStatucCode);
    }

    [Fact]
    public void DeleteProduct_ValidSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = 10,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        _productController.Post(product);
        var result = _productController.Delete(product.Sku);
        var actual = (result as OkObjectResult).StatusCode;
        var expected = new OkResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DeleteProduct_InvalidSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = -8,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        var result = _productController.Delete(product.Sku);
        var actual = (result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DeleteProduct_InexistentSku_Ok()
    {
        var product = new ProductModel
        {
            Sku = 889,
            Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
            Inventory = new InventoryModel
            {
                Warehouses = new List<WarehouseModel>
                {
                    new WarehouseModel
                    {
                        Locality = "Moema",
                        Quantity= 13,
                        Type = "PHYSICAL_STORE"
                    },
                    new WarehouseModel
                    {
                        Locality = "SP",
                        Quantity= 12,
                        Type = "ECOMMERCE"
                    },
                }
            }
        };
        var result = _productController.Delete(product.Sku);
        var actual = (result as BadRequestObjectResult).StatusCode;
        var expected = new BadRequestResult().StatusCode;

        Assert.Equal(expected, actual);
    }
}