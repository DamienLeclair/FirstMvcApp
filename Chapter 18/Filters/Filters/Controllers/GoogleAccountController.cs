using System.Web.Mvc;

namespace Filters.Controllers
{
    using System.Web.Security;

    public class GoogleAccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (username.EndsWith("@google.com") && password == "secret")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View();
            }
        }
    }
}