using LogicaAplicacion.Clientes;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using LogicaNegocio.InterfazRepositorio;
using Infraestructura.LogicaAccesoDatos.Listas;
using LogicaAplicacion.Usuarios;
using LogicaAplicacion.Dtos.Usuarios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// inteyeccion de dependcia. hace el new del objeto y lo pasa con su interfaz

// repositorios
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

// caso de uso -- Usuario --
builder.Services.AddScoped<IObtenerTodos<UsuarioDto>, GetAllUsuario>();
builder.Services.AddScoped<IAlta<UsuarioDto>, AltaUsuario>();
builder.Services.AddScoped<IObtener<UsuarioDto>, GetByIdUsuario>();
builder.Services.AddScoped<IEditar<UsuarioDto>, EditarUsuario>();
builder.Services.AddScoped<IEliminar<UsuarioDto>, EliminarUsuario>();

// caso de uso -- Cliente --
builder.Services.AddScoped<IFindByMonto<Cliente>, FindByMonto>();


// inyecta el contexto 
//builder.Services.AddDbContext<PedidoContext>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();
