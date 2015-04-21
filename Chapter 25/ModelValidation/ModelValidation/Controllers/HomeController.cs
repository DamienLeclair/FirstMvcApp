using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    using System;
    using ModelValidation.Models;

    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult MakeBooking()
        {
            return View(new Appointment{Date = DateTime.Now});
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            //if (string.IsNullOrEmpty(appt.ClientName))
            //{
            //    ModelState.AddModelError("ClientName", "Please enter your name");
            //}

            //if (ModelState.IsValidField("Date") && appt.Date < DateTime.Now)
            //{
            //    ModelState.AddModelError("Date", "Please enter a date in the future");
            //}

            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError("TermsAccepted", "You must accept the terms");
            //}

            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }

            return View();
        }

        public JsonResult ValidateDate(string date)
        {
            DateTime parseDate;

            if (!DateTime.TryParse(date, out parseDate))
            {
                return Json("Please enter a valid date format", JsonRequestBehavior.AllowGet);
            }

            if (parseDate < DateTime.Now)
            {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}