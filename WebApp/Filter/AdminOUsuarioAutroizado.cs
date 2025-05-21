using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filter
{
    public class AdminOUsuarioAutroizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "normal" && context.HttpContext.Session.GetString("rol") != "admin")
            {
                context.Result = new RedirectResult("/Usuario/Index");
            }
        }
    }
}
