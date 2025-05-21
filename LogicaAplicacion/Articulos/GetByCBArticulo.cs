using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Articulos
{
    public class GetByCBArticulo : IObtenerString<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public GetByCBArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public ArticuloDto Ejecutar(string Id)
        {
            Articulo articulo = _repositorioArticulo.GetByCB(Id);
            ArticuloDto articuloDto = ArticuloMapper.ToDto(articulo);
            return articuloDto;
        }
    }
}
