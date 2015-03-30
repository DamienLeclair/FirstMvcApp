using System.Web.Mvc;

namespace Filters.Controllers
{
    using Filters.Infrastructure;

    public class HomeController : Controller
    {
        //[CustomAuth(false)]
        [Authorize(Users = "admin")]
        public string Index()
        {
            return "This is the Index Action of the Home controller";
        }

        [GoogleAuth]
        public string List()
        {
            return "This is the List Action of the Home controller";
        }
    }
}