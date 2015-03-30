namespace Filters.Infrastructure
{
    using System.Web;
    using System.Web.Mvc;

    public class CustomAuthAttribute : AuthorizeAttribute
    {
        readonly bool localAllowed;

        public CustomAuthAttribute(bool localAllowed)
        {
            this.localAllowed = localAllowed;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return localAllowed;
            }

            return true;
        }
    }
}