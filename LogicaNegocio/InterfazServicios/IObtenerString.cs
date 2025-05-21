using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazServicios
{
    public interface IObtenerString<T>
    {
        public T Ejecutar(string id);
    }
}
