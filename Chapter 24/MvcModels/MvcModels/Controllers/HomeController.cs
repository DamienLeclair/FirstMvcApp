using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcModels.Controllers
{
    using System.Linq;
    using MvcModels.Models;

    public class HomeController : Controller
    {
        readonly IEnumerable<Person> personData = new[]
        {
            new Person { PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin },
            new Person { PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User },
            new Person { PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User },
            new Person { PersonId = 4, FirstName = "Anne", LastName = "Jones", Role = Role.Guest }
        };

        // GET: Home
        public ActionResult Index(int id)
        {
            return View(personData.First(p => p.PersonId == id));
        }
    }
}