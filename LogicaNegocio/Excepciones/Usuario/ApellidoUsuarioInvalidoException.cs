using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class ApellidoUsuarioInvalidoException : UsuarioException
    {
        public ApellidoUsuarioInvalidoException() : base("El Apelldo tiene que tener como minimo 2 caracteres") { }
    }
}
