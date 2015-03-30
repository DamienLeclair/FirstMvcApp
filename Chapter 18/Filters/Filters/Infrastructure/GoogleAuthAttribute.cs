namespace Filters.Infrastructure
{
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;
    using System.Web.Routing;

    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext context)
        {
            var ident = context.Principal.Identity;

            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                context.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "GoogleAccount"},
                    {"action", "Login"},
                    {"returnUrl", context.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}