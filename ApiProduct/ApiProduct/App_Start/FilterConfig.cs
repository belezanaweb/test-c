using System.Web;
using System.Web.Mvc;
using ApiProduct.Models;


namespace ApiProduct
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
   
}
