using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Linea
{
    public class UnidadInvalidaException : LineaException
    {
        public UnidadInvalidaException(string message) : base(message) { }

        public UnidadInvalidaException() : base("La cantidad de unidades es invalida") { }
    }
}
