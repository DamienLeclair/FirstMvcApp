using System.Web.Mvc;

namespace HelperMethods.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HelperMethods.Models;

    public class PeopleController : Controller
    {
        readonly IEnumerable<Person> personData = new[]
        {
            new Person { FirstName = "Adam", LastName = "Freeman", Role = Role.Admin },
            new Person { FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User },
            new Person { FirstName = "John", LastName = "Smith", Role = Role.User },
            new Person { FirstName = "Anne", LastName = "Jones", Role = Role.Guest }
        };

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetPeople()
        //{
        //    return View(personData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if (selectedRole == null || selectedRole == "All")
        //    {
        //        return View(personData);
        //    }

        //    var role = (Role)Enum.Parse(typeof(Role), selectedRole);
        //    return View(personData.Where(p => p.Role == role));
        //}

        //public PartialViewResult GetPeopleData(string selectedRole = "All")
        //{
        //    var data = personData;

        //    if (selectedRole != "All")
        //    {
        //        var role = (Role)Enum.Parse((typeof(Role)), selectedRole);
        //        data = personData.Where(p => p.Role == role);
        //    }

        //    return PartialView(data);
        //}

        IEnumerable<Person> GetData(string selectedRole)
        {
            var data = personData;

            if (selectedRole != "All")
            {
                var role = (Role)Enum.Parse((typeof(Role)), selectedRole);
                data = personData.Where(p => p.Role == role);
            }

            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole = "All")
        {
            var data =
                GetData(selectedRole)
                    .Select(
                        p =>
                            new
                            { 
                                p.FirstName, 
                                p.LastName,
                                Role = Enum.GetName(typeof(Role), p.Role)
                            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            return PartialView(GetData(selectedRole));
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
    }
}