using Infraestructura.LogicaAccesoDatos.EF;
using LogicaAplicacion.Articulos;
using LogicaAplicacion.Clientes;
using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaAplicacion.Pedidos;
using LogicaAplicacion.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
