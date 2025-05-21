using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Linea
{
    public class LineaException : DomainException
    {
        public LineaException(string message) : base(message) { }

        public LineaException() : base("Hubo un problema con la compra") { }
    }
}
