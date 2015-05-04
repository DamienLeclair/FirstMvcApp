using System.Web.Mvc;

namespace WebServices.Controllers
{
    using WebServices.Models;

    public class HomeController : Controller
    {
        //ReservationRepository repo = ReservationRepository.Current;

        public ActionResult Index()
        {
            //return View(repo.GetAll());
            return View();
        }

        //public ActionResult Add(Reservation item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repo.Add(item);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View("Index");
        //    }
        //}

        //public ActionResult Remove(int id)
        //{
        //    repo.Remove(id);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Update(Reservation item)
        //{
        //    if (ModelState.IsValid && repo.Update(item))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View("Index");
        //}
    }
}