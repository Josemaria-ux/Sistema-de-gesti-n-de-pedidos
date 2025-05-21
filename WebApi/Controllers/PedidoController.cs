using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        IObtenerTodos<PedidoDto> _getAll;
        IObtenerTodos<ArticuloDto> _getAllArticulos;
        IObtenerFecha<PedidoDto> _getAllFecha;
        IObtenerAnulados<PedidoDto> _obtenerAnulados;
        IAlta<Pedido> _alta;
        IObtener<PedidoDto> _obtener;
        IObtenerString<ArticuloDto> _obtenerCB;
        IObtener<ArticuloDto> _obtenerArticulo;
        IEditar<PedidoDto> _editar;
        IEliminar<PedidoDto> _eliminar;
        IObtener<ClienteDto> _obtenerCliente;
        public PedidoController(
            IObtenerTodos<PedidoDto> getAll,
            IObtenerFecha<PedidoDto> getAllFecha,
            IObtenerTodos<ArticuloDto> getAllArticulos,
            IAlta<Pedido> alta,
            IObtener<PedidoDto> obtener,
            IObtenerString<ArticuloDto> obtenerCB,
            IObtener<ArticuloDto> obtenerArticlo,
            IEditar<PedidoDto> editar,
            IEliminar<PedidoDto> eliminar,
            IObtenerAnulados<PedidoDto> obtenerAnulados,
            IObtener<ClienteDto> obtenerCliente
        )
        {
            _getAll = getAll;
            _getAllFecha = getAllFecha;
            _getAllArticulos = getAllArticulos;
            _alta = alta;
            _obtener = obtener;
            _obtenerCB = obtenerCB;
            _obtenerArticulo = obtenerArticlo;
            _editar = editar;
            _eliminar = eliminar;
            _obtenerAnulados = obtenerAnulados;
            _obtenerCliente = obtenerCliente;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAllAnulados()
        {
            try
            {
                return Ok(_obtenerAnulados.Ejecutar());
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
