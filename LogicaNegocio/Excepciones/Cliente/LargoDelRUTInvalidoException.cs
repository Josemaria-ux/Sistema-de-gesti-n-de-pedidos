using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class LargoDelRUTInvalidoException : ClienteException
    {
        public LargoDelRUTInvalidoException() : base("El RUT agrgado no cumple los requisitos de manera correcta.") { }

        public LargoDelRUTInvalidoException(string message) : base(message) { }
    }
}
