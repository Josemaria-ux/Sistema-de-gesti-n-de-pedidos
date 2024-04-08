using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class CalleInvalidaException : ClienteException
    {
        public CalleInvalidaException() : base("La calle ingresada no es correcta, debe tener mas de 2 caracteres.") { }
    }
}
