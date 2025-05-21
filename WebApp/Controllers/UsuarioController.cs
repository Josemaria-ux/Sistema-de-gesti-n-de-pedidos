
using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filter;

namespace WebApp.Controllers
{
    
    public class UsuarioController : Controller
    {
        IObtenerTodos<UsuarioDto> _getAll;
        IAlta<UsuarioDto> _alta;
        IObtener<UsuarioDto> _obtener;
        IEditar<UsuarioDto> _editar;
        IEliminar<UsuarioDto> _eliminar;
        ILogin<UsuarioDto> _obtenerLogin;

        public UsuarioController(
            IObtenerTodos<UsuarioDto> getAll,
            IAlta<UsuarioDto> alta,
            IObtener<UsuarioDto> obtener,
            IEditar<UsuarioDto> editar,
            IEliminar<UsuarioDto> eliminar,
            ILogin<UsuarioDto> login
        )
        {
            _getAll = getAll;
            _alta = alta;
            _obtener = obtener;
            _editar = editar;
            _eliminar = eliminar;
            _obtenerLogin = login;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Login(string Email, string Password)
        {
            try
            {
                if (Email != null && Password != null)
                {
                    UsuarioDto usuario = _obtenerLogin.Ejecutar(Email, Password);

                    if (usuario == null || usuario.Eliminado)
                    {
                        throw new Exception("No se encontro el usuario");
                    }
                    if (usuario.Discriminador.Equals(Admin.RolValor))
                    {
                        HttpContext.Session.SetString("rol", "admin");

                        return Redirect("/Admin/index");
                    }
                    else if (usuario.Discriminador.Equals(Normal.RolValor))
                    {
                        HttpContext.Session.SetString("rol", "normal");
                    }
                    HttpContext.Session.SetString("nombre", usuario.Nombre);
                    HttpContext.Session.SetString("id", Convert.ToString(usuario.Id));
                    return RedirectToAction("Details");
                }
                }catch (Exception ex)
            {
                ViewBag.mensaje = "sucedio un problema con su login, intente nuevamente";
            }
            return View("Index");
        }


        [AdminOUsuarioAutroizado]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");

            }
            catch
            {
                ViewBag.mensaje = "problema para cerrar sesion";
            }
            return View("Index");
        }


        [AdminOUsuarioAutroizado]
        public IActionResult Details()
        {
            int Id = Convert.ToInt16(HttpContext.Session.GetString("id"));
            try
                {
                    UsuarioDto User = _obtener.Ejecutar(Id);
                    if (User == null)
                    {
                        throw new Exception("No se encontro el id");
                    }
                    return View(User);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", new { mensaje = "No se encontró el usuario de Id: " + Id });
                }
            }
        }
    }
