using LogicaAplicacion.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using LogicaNegocio.InterfazRepositorio;
using Infraestructura.LogicaAccesoDatos.EF;
using LogicaAplicacion.Usuarios;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaAplicacion.Articulos;
using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaAplicacion.Pedidos;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.ValueObject;
using LogicaAplicacion.Dtos.Clientes;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// inteyeccion de dependcia. hace el new del objeto y lo pasa con su interfaz

// repositorios
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();

// caso de uso -- Usuario --
builder.Services.AddScoped<IObtenerTodos<UsuarioDto>, GetAllUsuario>();
builder.Services.AddScoped<IAlta<UsuarioDto>, AltaUsuario>();
builder.Services.AddScoped<IObtener<UsuarioDto>, GetByIdUsuario>();
builder.Services.AddScoped<IEditar<UsuarioDto>, EditarUsuario>();
builder.Services.AddScoped<IEliminar<UsuarioDto>, EliminarUsuario>();
builder.Services.AddScoped<ILogin<UsuarioDto>, Login>();

// caso de uso -- Cliente --
builder.Services.AddScoped<IObtenerTodos<ClienteDto>, GetAllClientes>();
builder.Services.AddScoped<IFindByMonto<ClienteDto>, FindByMonto>();
builder.Services.AddScoped<IObtener<ClienteDto>, GetByIdCliente>();
builder.Services.AddScoped<IFindByRazonSocial<ClienteDto>, FindByRazonSocial>();


// caso de uso -- Articulo --
builder.Services.AddScoped<IObtenerTodos<ArticuloDto>, GetAllArticulo>();
builder.Services.AddScoped<IAlta<ArticuloDto>, AltaArticulo>();
builder.Services.AddScoped<IObtener<ArticuloDto>, GetByIdArticulo>();
builder.Services.AddScoped<IObtenerString<ArticuloDto>, GetByCBArticulo>();
builder.Services.AddScoped<IEditar<ArticuloDto>, EditarArticulo>();
builder.Services.AddScoped<IEliminar<ArticuloDto>, EliminarArticulo>();

//caso de uso - Pedido --

builder.Services.AddScoped<IObtenerTodos<PedidoDto>, GetAllPedido>();
builder.Services.AddScoped<IObtenerFecha<PedidoDto>, GetAllFecha>();
builder.Services.AddScoped<IAlta<Pedido>, AltaPedido>();
builder.Services.AddScoped<IObtener<PedidoDto>, GetByIdPedido>();
builder.Services.AddScoped<IObtenerAnulados<PedidoDto>, GetAnulados>();
builder.Services.AddScoped<IEditar<PedidoDto>, EditarPedido>();
builder.Services.AddScoped<IEliminar<PedidoDto>, EliminarPedido>();




// inyecta el contexto 
//builder.Services.AddDbContext<PedidoContext>();

builder.Services.AddDbContext<PedidoContext>(
    options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("pedido")));

builder.Services.AddSession();


var config = new ConfigurationBuilder()
      .AddJsonFile("Parametros.json", optional: true, reloadOnChange: true)
      .Build();
Pedido.IVA = config.GetValue<int>("iva");
FPedido.plazoComun = config.GetValue<int>("plazoComun");
FPedido.plazoExpress = config.GetValue<int>("plazoExpress");
Pedido.RecargoExpress = config.GetValue<int>("recargoExpress");
Pedido.REntregaDia = config.GetValue<int>("rEntregaDia");
Pedido.RecargoDistancia = config.GetValue<int>("recargoDistancia");




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
