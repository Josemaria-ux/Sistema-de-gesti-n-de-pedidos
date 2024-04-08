using LogicaNegocio.Excepciones.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ArticuloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Alta()
        //{
        //    try
        //    {

        //    }catch (ArticuloException ex)
        //    {

        //    }
        //}
    }
}
