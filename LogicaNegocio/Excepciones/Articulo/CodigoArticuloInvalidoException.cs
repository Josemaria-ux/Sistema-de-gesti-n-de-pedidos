using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class CodigoArticuloInvalidoException : ArticuloException
    {
        public CodigoArticuloInvalidoException() : base("El codigo del articulo es invalido.")
        {

        }
    }
}
