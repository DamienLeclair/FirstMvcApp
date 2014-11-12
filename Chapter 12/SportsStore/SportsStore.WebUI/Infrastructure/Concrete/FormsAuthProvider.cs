using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    using System.Web.Security;
    using SportsStore.WebUI.Infrastructure.Abstract;

    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string userName, string password)
        {
            var result = FormsAuthentication.Authenticate(userName, password);

            if(result)
                FormsAuthentication.SetAuthCookie(userName, false);

            return result;
        }
    }
}