using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using SportsStore.Domain.Abstract;
    using SportsStore.WebUI.Models;

    public class ProductController : Controller
    {
        readonly IProductsRepository repository;

        public int PageSize = 4;

        public ProductController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(string category = null, int page = 1)
        {
            var products =
                repository.Products.Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null 
                    ? repository.Products.Count()
                    : repository.Products.Count(e => e.Category == category)
            };

            var model = new ProductsListViewModel
            {
                Products = products,
                PagingInfo = pagingInfo,
                CurrentCategory = category
            };

            return View(model);
        }
	}
}