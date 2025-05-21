using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filter
{
    public class UsuarioAutorizado : Attribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "normal")
            {
                context.Result = new RedirectResult("/Usuario/Index");
            }
        }
    }
}
