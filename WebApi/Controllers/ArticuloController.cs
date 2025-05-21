using LogicaAplicacion.Dtos.Articulos;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_getAll.Ejecutar());
            }
            //catch (NotFoundException e)
            //{
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }
        }

       
    }
}