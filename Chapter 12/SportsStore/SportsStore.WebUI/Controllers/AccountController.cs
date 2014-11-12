using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using SportsStore.WebUI.Infrastructure.Abstract;
    using SportsStore.WebUI.Models;

    public class AccountController : Controller
    {
        readonly IAuthProvider auth;

        public AccountController(IAuthProvider auth)
        {
            this.auth = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (auth.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                
                ModelState.AddModelError("", "Incorect username or password");
                return View();
            }
            return View();
        }
    }
}