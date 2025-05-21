using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class NombreArticuloInvalidoException : ArticuloException
    {
        public NombreArticuloInvalidoException(string? message) : base(message)
        {

        }
        public NombreArticuloInvalidoException() : base("El nombre del articulo es invalido.")
        {

        }
    }
}
