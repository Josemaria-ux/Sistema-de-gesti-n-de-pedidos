using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
namespace LogicaAplicacion.Articulos
{
    public class EditarArticulo : IEditar<ArticuloDto>
    {
        IRepositorioArticulo _repoArticulo;

        public EditarArticulo(IRepositorioArticulo repoArticulo)
        {
            _repoArticulo = repoArticulo;
        }

        public void Ejecutar(int id, ArticuloDto obj)
        {
            Articulo articulo = ArticuloMapper.FromDto(obj);
            _repoArticulo.Update(id, articulo);
        }
    }
}

