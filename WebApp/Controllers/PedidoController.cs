using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
