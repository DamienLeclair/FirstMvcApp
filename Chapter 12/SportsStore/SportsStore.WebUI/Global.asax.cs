using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    using SportsStore.Domain.Concrete;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Infrastructure.Binders;
    using System.Data.Entity;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            Database.SetInitializer<EFDbContext>(null);
        }
    }
}
