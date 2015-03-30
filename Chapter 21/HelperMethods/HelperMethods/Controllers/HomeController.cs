using System.Web.Mvc;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Fruits = new[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new[] { "New York", "London", "Paris" };

            const string message = "This is an HTML element : <input>";

            return View((object)message);
        }
    }
}