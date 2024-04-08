using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    internal class PrecioArticuloInvalidoException : ArticuloException
    {
        public PrecioArticuloInvalidoException() : base("El precio del articulo es invalido.")
        {

        }
    }
}
