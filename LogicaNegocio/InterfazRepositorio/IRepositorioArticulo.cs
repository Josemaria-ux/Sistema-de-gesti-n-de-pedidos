using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {

        public IEnumerable<Articulo> GetAll();

    }
}
