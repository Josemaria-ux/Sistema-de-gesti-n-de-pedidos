using LogicaAplicacion.Clientes;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ClienteController : Controller
    {
        FindByMonto _findByMonto = new FindByMonto();

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]

        public IActionResult BuscarPorMonto(double monto)
        {
            try
            {
                return RedirectToAction("BuscarPorMonto", _findByMonto.Ejecutar(monto));
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("Index", new { message = ex.Message});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { message = "No se puedo buscar el/los clientes. Intente nuevamente." });
            }
            
        }

        public IActionResult BuscarPorMonto(IEnumerable<Cliente> lista)
        {
            return View(lista);
        }

        public IActionResult BuscarPorNombreOApellido()
        {
            return View();
        }
    }
}
