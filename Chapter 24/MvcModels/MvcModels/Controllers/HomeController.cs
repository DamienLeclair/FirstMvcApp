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
        public ActionResult Index(int? id = 1)
        {
            var person = personData.First(p => p.PersonId == id);
            return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(IEnumerable<string> names)
        {
            return View(names ?? Enumerable.Empty<string>());
        }

        public ActionResult Address(IEnumerable<AddressSummary> address)
        {
            return View(address ?? Enumerable.Empty<AddressSummary>());
        }

        //public ActionResult Address(FormCollection formData)
        //{
        //    var addresses = new List<AddressSummary>();
        //    if (TryUpdateModel(addresses, formData))
        //    {
        //        // Procced as normal
        //    }
        //    else
        //    {
        //        // Provide feedbac to user
        //    }
        //    return View(addresses);
        //}
    }
}