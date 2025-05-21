using LogicaAplicacion.Dtos.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
namespace LogicaAplicacion.Dtos.MapeosDto
{
    public class ArticuloMapper
    {
        public static Articulo FromDto(ArticuloDto articuloDto)
        {
            return new Articulo()
            {
                Nombre = new NombreArticulo(articuloDto.Nombre),
                Descripcion = articuloDto.Descripcion,
                CodigoBarras = new CodigoBarras(articuloDto.CodigoBarras),
                Precio = new Precio(articuloDto.Precio),
                Stock = articuloDto.Stock,
                Eliminado = articuloDto.Eliminado
            };
        }

        public static ArticuloDto ToDto(Articulo articulo)
        {
            return new ArticuloDto(articulo.Id, articulo.Nombre.Name, articulo.Descripcion, articulo.CodigoBarras.Value, articulo.Precio.Value,articulo.Stock,articulo.Eliminado);
        }

        public static IEnumerable<ArticuloDto> ToListaDto(IEnumerable<Articulo> articulos)
        {
            List<ArticuloDto> aux = new List<ArticuloDto>();
            foreach (var articulo in articulos)
            {
                ArticuloDto articuloDto = ArticuloMapper.ToDto(articulo);
                aux.Add(articuloDto);
            }
            aux.Sort();
            return aux;
        }
    }
}
