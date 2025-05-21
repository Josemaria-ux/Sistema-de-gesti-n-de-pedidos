using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class NumeroInvalidoException : ClienteException
    {
        public NumeroInvalidoException() : base("El Numero de la direccion no es correcta, deberia ser mayor a 0") { }

        public NumeroInvalidoException(string message) : base(message) { }
    }
}
