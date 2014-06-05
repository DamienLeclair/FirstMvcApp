using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;

    public class ProductController : Controller
    {
        readonly IProductsRepository productsRepository;

        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ViewResult List(int page = 1)
        {
            var model = new ProductListViewModel
            {
                Products =
                    productsRepository.Products.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo =
                    new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = productsRepository.Products.Count()
                    }
            };

            return View(model);
        }
	}
}