using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace TesteBotica.Controllers
{
    [RoutePrefix("api/test/botica/product")]
    public class ProductController : Controller
    {
        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                if (products == null)
                {
                    DataManager.ProductDataManager productDataManager = new DataManager.ProductDataManager();
                    products = productDataManager.Load();
                }

                return products;
            }
        }
        // GET: api/test/botica/product
        public ActionResult Index()
        {
            return View();
        }

        // GET: api/test/botica/product/Details/43264
        public ActionResult Details(int id)
        {
            Product product = Products.FirstOrDefault(x => x.Sku == id);
            product.Inventory.Warehouses.FirstOrDefault(x => x.Quantity > 0).Quantity--;
            return View(product);
        }

        // GET: api/test/botica/product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: api/test/botica/product/Create
        [System.Web.Http.HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product p)
        {
            try
            {
                if (p.Sku > 0)
                {
                    if (Products.FindAll(x => x.Sku == p.Sku).Count > 0)
                        return Json(new { status = "error", message = "error creating product" });
                }
                else
                {
                    long sku = Products.Max(x => x.Sku);
                    p.Sku = sku++;
                }

                //Validar campos
                //Salvar

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        // POST: api/test/botica/product/Edit/43264
        [System.Web.Http.HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Product p)
        {
            try
            {
                Product product = Products.FirstOrDefault(x => x.Sku == p.Sku);
                product = p;
                //Validar campos
                //Salvar

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ProductController/Delete/43264
        [System.Web.Http.HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Product p)
        {
            try
            {
                Product product = Products.FirstOrDefault(x => x.Sku == p.Sku);
                //Deletar
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
