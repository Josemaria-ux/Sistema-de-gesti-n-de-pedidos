using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Clientes;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{

    [AdminAutorizado]
    public class ArticuloController : Controller
    {
        IObtenerTodos<ArticuloDto> _getAll;
        IAlta<ArticuloDto> _alta;
        IObtener<ArticuloDto> _obtener;
        IEditar<ArticuloDto> _editar;
        IEliminar<ArticuloDto> _eliminar;

        public ArticuloController(
            IObtenerTodos<ArticuloDto> getAll,
            IAlta<ArticuloDto> alta,
            IObtener<ArticuloDto> obtener,
            IEditar<ArticuloDto> editar,
            IEliminar<ArticuloDto> eliminar
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

        public IActionResult Create(string mensaje)
        {
            ViewBag.Message = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticuloDto articuloDto)
        {
            try
            {
                _alta.Ejecutar(articuloDto);
                return RedirectToAction("Index", new { mensaje = "El usuario fue creado correctamente" });
            }
            catch (ArticuloException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", new { mensaje = "No se crear el usuario. Intente nuevamente." });
            }
        }

        public IActionResult Edit(string mensaje, int Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = mensaje;
            ArticuloDto articuloDto = _obtener.Ejecutar(Id);
            if (articuloDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el usuario" });
            }
            return View(articuloDto);
        }
        
        [HttpPost]
        public IActionResult Edit(ArticuloDto articuloDto, int Id)
        {
            try
            {
                _editar.Ejecutar(Id, articuloDto);
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

        public IActionResult Delete(string mensaje, int Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = mensaje;
            ArticuloDto articuloDto = _obtener.Ejecutar(Id);
            if (articuloDto == null)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el usuario" });
            }
            return View(articuloDto);
        }

        [HttpPost]
        public IActionResult Delete( int Id)
        {
            try
            {
                _eliminar.Ejecutar(Id);
                return RedirectToAction("Index", new { mensaje = "Eliminado correctamente." });
            }
            catch (UsuarioException e)
            {
                return RedirectToAction("Edit", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Edit", new { mensaje = "No se pudo eliminar, intentelo mas tarde nuevamente" });
            }
        }

        public IActionResult Details(int Id)
        {
            try
            {
                ArticuloDto art = _obtener.Ejecutar(Id);
                if (art == null)
                {
                    throw new Exception("No se encontro el id");
                }
                return View(art);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el Articulo de Id: " + Id });
            }
        }

    }
}
