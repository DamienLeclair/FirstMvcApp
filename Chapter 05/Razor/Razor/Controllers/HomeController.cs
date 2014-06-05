using System.Web.Mvc;

namespace Razor.Controllers
{
    using System;
    using Razor.Models;

    public class HomeController : Controller
    {
        readonly Product myProduct = new Product
        {
            ProductId = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpressions()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            var products = new[]
            {
                new Product { Name = "Kayak", Price = 2755M }, 
                new Product { Name = "Lifejacket", Price = 48.95M }, 
                new Product { Name = "Soccer ball", Price = 19.50M }, 
                new Product { Name = "Corner flag", Price = 34.95M }, 
            };

            return View(products);
        }
	}
}