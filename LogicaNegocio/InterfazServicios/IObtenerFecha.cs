using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazServicios
{
    public interface IObtenerFecha<T>
    {
        public IEnumerable<T> Ejecutar(DateTime fecha);
    }
}
