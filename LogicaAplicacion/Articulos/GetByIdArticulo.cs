using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;


namespace LogicaAplicacion.Articulos
{
    public class GetByIdArticulo : IObtener<ArticuloDto>
    {
        IRepositorioArticulo _repoArticulo;

        public GetByIdArticulo(IRepositorioArticulo repoArticulo)
        {
            _repoArticulo = repoArticulo;
        }

        public ArticuloDto Ejecutar(int Id)
        {
            Articulo articulo = _repoArticulo.GetById(Id);
            ArticuloDto articuloDto = ArticuloMapper.ToDto(articulo);
            return articuloDto;
        }

    }
}
