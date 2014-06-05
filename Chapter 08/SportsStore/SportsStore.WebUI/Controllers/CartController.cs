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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveToCart(int productId, string returnUrl)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}