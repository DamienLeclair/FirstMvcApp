using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    [RoutePrefix("User")]
    public class CustomerController : Controller
    {

        [Route("~/Test")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [Route("Add/{user}/{id:int}")]
        public string Create(string user, int id)
        {
            return string.Format("Create method - User : {0}, ID : {1}", user, id);
        }

        [Route("Add/{user}/{password:alpha:length(6)}")]
        public string ChangePassword(string user, string password)
        {
            return string.Format("Change password method - User : {0}, Password : {1}", user, password);
        }

        public ActionResult List()
        {
            ViewBag.Controller = "Customer";
            ViewBag.Action = "List";
            return View("ActionName");
        }
	}
}