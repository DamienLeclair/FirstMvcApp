namespace SportsStore.WebUI.Controllers
{
    using System.Web.Mvc;
    using SportsStore.Domain.Abstract;

    public class AdminController : Controller
    {
        readonly IProductsRepository repository;

        public AdminController(IProductsRepository repository)
        {
            this.repository = repository;
        }
        
        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}