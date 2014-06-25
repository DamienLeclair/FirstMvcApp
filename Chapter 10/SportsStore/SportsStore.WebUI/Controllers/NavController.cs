using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using SportsStore.Domain.Abstract;

    public class NavController : Controller
    {
        readonly IProductsRepository repository;

        public NavController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category;

            var categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            var viewName = horizontalLayout ? "MenuHorizontal" : "Menu";

            return PartialView(viewName, categories);
        }
    }
}