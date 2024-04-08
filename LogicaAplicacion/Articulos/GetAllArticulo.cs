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
 
    public class GetAllArticulo : IObtenerTodos<Articulo>
    {
        IRepositorioArticulo _repositorioArticulo;

        public GetAllArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<Articulo> Ejecutar()
        {
            return _repositorioArticulo.GetAll(); ;
        }
    }
}
