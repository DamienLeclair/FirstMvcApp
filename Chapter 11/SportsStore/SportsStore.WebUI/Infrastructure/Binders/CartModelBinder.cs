namespace SportsStore.WebUI.Infrastructure.Binders
{
    using System.Web.Mvc;
    using SportsStore.Domain.Entities;

    public class CartModelBinder : IModelBinder
    {
        const string SESSION_KEY = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the cart from the session
            Cart cart = null;
            var session = controllerContext.HttpContext.Session;
            if (session != null)
            {
                cart = (Cart)session[SESSION_KEY];
            }

            // create the cart if there wasn't one in the session
            if (cart == null)
            {
                cart = new Cart();

                if (session != null)
                {
                    session[SESSION_KEY] = cart;
                }
            }

            // return the cart
            return cart;
        }
    }
}