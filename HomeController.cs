using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteProdutoSolange.Models;
using TesteProdutoSolange.Repository;

namespace TesteProdutoSolange.Controllers
{
    public class HomeController : Controller
    {
        ProdutoRepository rep = new ProdutoRepository();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(rep.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetContaById(int id)
        {
            return Json(rep.GetById(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Create(Produto produto)
        {
            int total = 0;
            foreach (var item in produto.inventory.warehouse)
            {
                total += total + item.quantity;
            }
            produto.inventory.quantity = total;


            if(produto.inventory.quantity == 0)
            {
                produto.isMarketable = true;
            }

            rep.Save(produto);
        }

        [HttpPost]
        public void Delete(int id)
        {
            rep.Delete(id);
        }

        [HttpPost]
        public void Update(Produto produto)
        {
            rep.Update(produto);
        }


    }
}