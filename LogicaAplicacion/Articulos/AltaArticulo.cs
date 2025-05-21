
using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;

namespace LogicaAplicacion.Articulos
{
    public class AltaArticulo : IAlta<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public AltaArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(ArticuloDto articulo)
        {
            Articulo art = ArticuloMapper.FromDto(articulo);
            _repositorioArticulo.Add(art);
        }

    }
}
