using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    using System.Linq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Models;

    public class CartController : Controller
    {
        readonly IProductsRepository repository;

        public CartController(IProductsRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveToCart(Cart cart, int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}