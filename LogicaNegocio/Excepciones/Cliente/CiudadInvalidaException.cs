using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class CiudadInvalidaException : ClienteException
    {
        public CiudadInvalidaException(): base ("La ciudad ingresada no es la correcta debe tener mas de 2 caracteres") { }
    }
}
