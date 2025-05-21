using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaAplicacion.Dtos.Lineas;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Filter;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Excepciones.Linea;

namespace WebApp.Controllers
{
    [AdminAutorizado]
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
        public IActionResult Index()
        {
            try
            {
                return View(_getAll.Ejecutar());
            }
            catch (PedidoException ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo acceder a los articulos. Intente nuevamente." });
            }
        }

        public IActionResult ListarPedidosEliminar(DateTime? fecha)
        {
           
            try
            {
                if (fecha != null)
                {
                    return View(_getAllFecha.Ejecutar((DateTime)fecha));
                }
                else{
                    return View(_getAll.Ejecutar());
                }
               
            }
            catch (PedidoException ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo acceder a los articulos. Intente nuevamente." });
            }
        }

        public IActionResult ListaArticulos()
        {
            try
            {
                return View(_getAllArticulos.Ejecutar());
            }
            catch (PedidoException ex)
            {
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", new { mensaje = "No se pudo acceder a los articulos. Intente nuevamente." });
            }
        }

        public IActionResult Create(string mensaje)
        {
            try
            {
                if (!string.IsNullOrEmpty(mensaje)){
                    ViewBag.Error = true;
                }
                PedidoDto pedidoDto = GetComprasFromSession();
                ViewBag.Message = mensaje;
               
                return View(pedidoDto);
            }
            catch (PedidoException ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (LineaException ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = "No se pudo crear el pedido. Intente nuevamente." });
            }
        }





        [HttpPost]

        public IActionResult Create(PedidoDto pedidoDto)
        {
            try
            {
                pedidoDto.FPedido= DateTime.Now;
                Pedido pedido = PedidoMapper.FromDto(pedidoDto);
                pedido.Cliente = ClienteMapper.FromDto(_obtenerCliente.Ejecutar(pedidoDto.ClienteId));
                pedido.Lineas = obtenerLineas();
                pedido.CalcularCostoTotal();
                _alta.Ejecutar(pedido);
                VaciarCarrito();
                return RedirectToAction("Index", new { mensaje = "El pedido fue creado correctamente" });
            }
            catch (PedidoException ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (ArticuloException ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (ClienteException ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                return RedirectToAction("Create", new { mensaje = "No se creo el pedido, Intente nuevamente." });
            }
        }



        public List<Linea> obtenerLineas()
        {
            PedidoDto pedidoDto = GetComprasFromSession();
            Linea unaL;
            List<Linea> aux = new List<Linea>();
            foreach (var item in pedidoDto.Items)
            {
                unaL = LineaMapper.FromDto(item);
                unaL.Articulo = ArticuloMapper.FromDto(_obtenerArticulo.Ejecutar(unaL.ArticuloId));
                aux.Add(unaL);
            }
            return aux;

        }


        public IActionResult Details(int Id)
        {
            try
            {
                PedidoDto pedido = _obtener.Ejecutar(Id);
                if (pedido == null)
                {
                    throw new Exception("No se encontro el id");
                }
                return View(pedido);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el usuario de Id: " + Id });
            }
        }

        public IActionResult Anular(string mensaje, int id)
        {
            try
            {
                PedidoDto pedido = _obtener.Ejecutar(id);
                if (pedido == null)
                {
                    throw new Exception("No se encontro el id");
                }
                return View(pedido);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { mensaje = "No se encontró el usuario de Id: " + id });
            }
        }

        [HttpPost]

        public IActionResult Anular(int Id)
        {
            try
            {
                _eliminar.Ejecutar(Id);
                return RedirectToAction("Index", new { mensaje = "Eliminado correctamente." });
            }
            catch (PedidoException e)
            {
                return RedirectToAction("Index", new { mensaje = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { mensaje = "No se pudo eliminar, intentelo mas tarde nuevamente" });
            }
        }

        public IActionResult GetAnuladosa()
        {
            return View(_obtenerAnulados.Ejecutar());
        }

        public IActionResult AgregarItem(string CodigoBarras, int unidades)
        {
            try
            {
                if (unidades <= 0)
                {
                    throw new Exception("Se debe indiacar las unidades del articulo");
                }
                ArticuloDto articulo = _obtenerCB.Ejecutar(CodigoBarras);
                if (articulo == null)
                {
                    throw new Exception("Debe seleccionar un articulo.");
                }
                PedidoDto pedidoDto = GetComprasFromSession();
                if (pedidoDto == null)
                {
                    throw new Exception("No se pudo recuperar la compra");
                }
                LineaDto item = new LineaDto()
                {
                    Id = articulo.Id,
                    ArticuloNombre = articulo.Nombre,
                    ArticuloId = articulo.Id,

                    Unidades = unidades,
                    Precio = articulo.Precio
                };
                LineaDto lineaDto = ObtenerLineaDto(pedidoDto,item);
                if (lineaDto == null)
                {
                    pedidoDto.Items.Add(item);
                }
                else
                {
                    lineaDto.Unidades += unidades;
                }
                pedidoDto.Unudades += unidades;
                pedidoDto.CostoTotal += articulo.Precio * unidades;
                SetViewBag(pedidoDto);
                SetComprasToSession(pedidoDto);
                ViewBag.Error = false;
                ViewBag.Mensaje = "Se dio de alta con exito";
            }
            catch (Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
            }
            return View("ListaArticulos", _getAllArticulos.Ejecutar());
        }

        public LineaDto ObtenerLineaDto(PedidoDto pedidoDto, LineaDto linea)
        {
            foreach (var unaLineaDto in pedidoDto.Items)
            {
                if (unaLineaDto.Id == linea.ArticuloId)
                {
                    return unaLineaDto;
                }
            }
            return null;
        }


        public IActionResult EliminarLinea(string mensaje, int ArticuloId)
        {
           
            try
            {
                ViewBag.Message = mensaje;
                PedidoDto pedidoDto = GetComprasFromSession();
                bool elimino= false;
                foreach (var item in pedidoDto.Items)
                {
                    if(item.ArticuloId == ArticuloId)
                    {
                        pedidoDto.Items.Remove(item);
                        SetViewBag(pedidoDto);
                        SetComprasToSession(pedidoDto);
                        return RedirectToAction("Create");
                    }                    
                }
                throw new Exception("No se encontro el producto");
       
            }
            catch(Exception e)
            {
                ViewBag.Error = true;
                ViewBag.Mensaje = e.Message;
                return RedirectToAction("Create", new { mensaje = e.Message });
            }
            
        }

        public void Checkout(int IdCliente, DateTime entrega)
        {
            PedidoDto pedidoDto = GetComprasFromSession();
            if (pedidoDto == null)
            {
                throw new Exception("No se pudo recuperar la compra");
            }
            pedidoDto.ClienteId = IdCliente;
            pedidoDto.FEntrega = entrega;
            // llamo al caso de uso de comprar

        }

        private PedidoDto GetComprasFromSession()
        {
            PedidoDto PedidoDtoRecuperado;
            string? json = HttpContext.Session.GetString("SessionPedidoDto");
            if (string.IsNullOrEmpty(json))
            {
                PedidoDtoRecuperado = new PedidoDto();
            }
            else
            {
                PedidoDtoRecuperado = JsonSerializer.Deserialize<PedidoDto>(json);
                PedidoDtoRecuperado.CostoTotal = Math.Round(PedidoDtoRecuperado.CostoTotal, 2);
            }
            return PedidoDtoRecuperado;
        }

        private void SetComprasToSession(PedidoDto compraDto)
        {
            HttpContext.Session.SetString("SessionPedidoDto", JsonSerializer.Serialize(compraDto));
        }

        private void VaciarCarrito()
        {
            PedidoDto pedidoDto = GetComprasFromSession();
            pedidoDto.Unudades = 0;
            pedidoDto.CostoTotal = 0;
            pedidoDto.Items.Clear();
            SetViewBag(pedidoDto);
            SetComprasToSession(pedidoDto);
        }

        private void SetViewBag(PedidoDto pedidoDto)
        {
            ViewBag.cantidad = pedidoDto.Unudades;
            ViewBag.total = pedidoDto.CostoTotal;
            ViewBag.catalogo = pedidoDto.Items;
        }
    }
}
