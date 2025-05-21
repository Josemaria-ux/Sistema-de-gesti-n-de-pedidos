using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class PrecioException : DomainException
    {
        public PrecioException(string message) : base(message) { }

        public PrecioException() : base("El precio es invalido") { }
    }
}
