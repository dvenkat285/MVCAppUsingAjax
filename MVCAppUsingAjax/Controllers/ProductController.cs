using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppUsingAjax.Models;

namespace MVCAppUsingAjax.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities dc = new NorthwindEntities();
        public ActionResult Index()
        {
           // var products= from p in dc.Products select new {P.ProductID, P.ProductName, P.CategoryID, P.UnitPrice, P.UnitsInStock };
            //var products = dc.Products.Select(); or
            return View(dc.Products);
        }
        public ViewResult SearchProduct(string SearchTerm)
        {
            List<Product> Products;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Products = dc.Products.ToList();
            }
            else
            {

                //Products = (from P in dc.Products where P.ProductName.Contains(SearchTerm) select P).ToList(); or
                Products = dc.Products.Where(P=>P.ProductName.Contains(SearchTerm)).ToList();
            }
            return View("Index", Products);
        }
    }
}