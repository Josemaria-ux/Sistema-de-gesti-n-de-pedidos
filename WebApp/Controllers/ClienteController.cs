using LogicaAplicacion.Clientes;
using LogicaAplicacion.Dtos.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    [AdminAutorizado]
    public class ClienteController : Controller
    {
        IObtenerTodos<ClienteDto> _getAll;
        IFindByMonto<ClienteDto> _findByMonto;
        IObtener<ClienteDto> _obtener;
        IFindByRazonSocial<ClienteDto> _findByRazonSocail;

        public ClienteController(
            IObtenerTodos<ClienteDto> getAll,
            IFindByMonto<ClienteDto> findByMonto,
            IObtener<ClienteDto> obtener,
            IFindByRazonSocial<ClienteDto> findByRazonSocail
        )
        {
            _getAll = getAll;
            _findByMonto = findByMonto;
            _obtener = obtener;
            _findByRazonSocail = findByRazonSocail;
        }


        public IActionResult Index(string message, double monto, string rs)
        {
            ViewBag.Message = message;
            IEnumerable<ClienteDto> res;
            if (monto != null && monto > 0)
            {
                res = _findByMonto.Ejecutar(monto);
            }
            else if (rs != null && rs != "")
            {
                res = _findByRazonSocail.Ejecutar(rs);
            }
            else
            {
                res = _getAll.Ejecutar();
            }
            return View(res);
        }


        public IActionResult Details(int Id)
        {
            try
            {
                ClienteDto cli = _obtener.Ejecutar(Id);
                if (cli == null)
                {
                    throw new Exception("No se encontro el id");
                }
                return View(cli);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el Cliente de Id: " + Id });
            }
        }

    }
}
