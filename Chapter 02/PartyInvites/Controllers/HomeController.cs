using System;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    using PartyInvites.Models;

    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", response);
            }
            
            return View();
        }
    }
}