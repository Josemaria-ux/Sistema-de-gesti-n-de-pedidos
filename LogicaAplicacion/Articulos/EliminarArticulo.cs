using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Articulos
{
    public class EliminarArticulo : IEliminar<ArticuloDto>
    {
        IRepositorioArticulo _repoArticulo;

            public EliminarArticulo(IRepositorioArticulo repoArticulo)
            {
            _repoArticulo = repoArticulo;
            }

            public void Ejecutar(int id)
            {
            _repoArticulo.Delete(id);
            }
        }
}
