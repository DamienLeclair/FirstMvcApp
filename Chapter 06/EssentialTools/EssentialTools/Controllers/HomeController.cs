namespace EssentialTools.Controllers
{
    using System.Web.Mvc;
    using EssentialTools.Models;

    public class HomeController : Controller
    {
        readonly IValueCalculator calc;

        readonly Product[] products =
        {
            new Product { Name = "Kayak", Price = 275M },
            new Product { Name = "Lifejacket", Price = 48.95M }, 
            new Product { Name = "Soccer ball", Price = 19.50M },
            new Product { Name = "Corner flag", Price = 34.95M }
        };

        public HomeController(IValueCalculator calc, IValueCalculator calc2)
        {
            this.calc = calc;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            //var ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            
            //var calc = new LinqValueCalculator();
            //var calc = ninjectKernel.Get<IValueCalculator>();

            var cart = new ShoppingCart(calc) { Products = products };

            var totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
	}
}