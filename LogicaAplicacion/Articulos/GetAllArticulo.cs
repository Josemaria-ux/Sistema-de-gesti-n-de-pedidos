using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;


namespace LogicaAplicacion.Articulos
{
 
    public class GetAllArticulo : IObtenerTodos<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public GetAllArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<ArticuloDto> Ejecutar()
        {
            IEnumerable<ArticuloDto> articuloDtos = ArticuloMapper.ToListaDto(_repositorioArticulo.GetAll());
            return articuloDtos; ;
        }

    }
}
