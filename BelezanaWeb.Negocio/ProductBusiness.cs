using BelezanaWeb.Business.Interfaces;
using BelezanaWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BelezanaWeb.Data;

namespace BelezanaWeb.Business
{
    public class ProductBusiness : IProductBusiness
    {
        List<Product> products;

        public ProductBusiness()
        {
            this.products = BelezanaWeb.Data.Data.Produtos();
        }

        public virtual Product Get(int id)
        {
            try
            {
                var product = this.products.Find(x => x.Sku == id);

                return CalcQuantity(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<Product> Get()
        {
            try
            {
                var products = ProcessedList(this.products);

                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Product Insert(Product product)
        {
            try
            {
                if (!this.products.Any(x => x.Sku == product.Sku))
                {
                    this.products.Add(product);

                    return CalcQuantity(product);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Product Update(int id, Product product)
        {
            try
            {
                var productDB = this.products.Find(x => x.Sku == id);

                if (productDB != null)
                {
                    this.products.Remove(productDB);

                    this.products.Add(product);

                    return CalcQuantity(product);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Product Delete(int id)
        {
            try
            {
                var product = this.products.Find(x => x.Sku == id);

                this.products.Remove(product);

                return CalcQuantity(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> ProcessedList(List<Product> products)
        {
            return this.products.Select(x => CalcQuantity(x)).ToList();
        }

        public Product CalcQuantity(Product product)
        {
            return new Product
            {
                Sku = product.Sku,
                Name = product.Name,
                IsMarketable = product.Inventory.Warehouses.Sum(q => q.Quantity) > 0,
                Inventory = new Inventory
                {
                    Quantity = product.Inventory.Warehouses.Sum(q => q.Quantity),
                    Warehouses = product.Inventory.Warehouses
                }
            };
        }
    }
}