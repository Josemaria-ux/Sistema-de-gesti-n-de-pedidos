using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaAplicacion.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        IObtenerTodos<UsuarioDto> _getAll;
        IAlta<UsuarioDto> _alta;
        IObtener<UsuarioDto> _obtener;
        IEditar<UsuarioDto> _editar;
        IEliminar<UsuarioDto> _eliminar;

        public UsuarioController(
            IObtenerTodos<UsuarioDto> getAll,
            IAlta<UsuarioDto> alta,
            IObtener<UsuarioDto> obtener,
            IEditar<UsuarioDto> editar,
            IEliminar<UsuarioDto> eliminar
        )
        {
            _getAll = getAll;
            _alta = alta;
            _obtener = obtener;
            _editar = editar;
            _eliminar = eliminar;
        }

        public IActionResult Index(string mensaje)
        {
            ViewBag.Message = mensaje;
            return View(_getAll.Ejecutar());
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int Id)
        {
            return View();
        }

        public IActionResult Create(string mensaje)
        {
            ViewBag.Message = mensaje;
            return View();
        }

        [HttpPost]

        public IActionResult Create(UsuarioDto usuarioDto)
        {
            try
            {
                _alta.Ejecutar(usuarioDto);
                return RedirectToAction("Index", new { mensaje = "El usuario fue creado correctamente" });
            }
            catch (UsuarioException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", new { mensaje = "No se crear el usuario. Intente nuevamente." });
            }
        }

        public IActionResult Details() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(int Id)
        {
            return View();
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                _eliminar.Ejecutar(Id);
                return RedirectToAction("Index", new { mensaje = "Eliminado correctamente." });
            }
            catch (NotFoundException e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo elimianar, intentelo mas tarde nuevamente" });
            }
        }

        public IActionResult Edit(string mensaje, int Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = mensaje;
            UsuarioDto usuarioDto = _obtener.Ejecutar(Id);
            if (usuarioDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el usuario"});
            }
            return View(usuarioDto);
        }

        [HttpPost]
        public IActionResult Edit(UsuarioDto usuarioDto, int Id)
        {
            try
            {
                _editar.Ejecutar(Id, usuarioDto);
                return RedirectToAction("Index", new { mensaje = "Editado correctamente." });
            }
            catch (UsuarioException e)
            {
                return RedirectToAction("Edit", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Edit", new { mensaje = "No se pudo editar, intentelo mas tarde nuevamente" });
            }
        }
    }
}
