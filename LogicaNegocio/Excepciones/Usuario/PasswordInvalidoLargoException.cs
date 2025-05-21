using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class PasswordInvalidoLargoException : UsuarioException
    {
        public PasswordInvalidoLargoException() : base("La contraseña es invalida, tiene que tener 5 caracteres como minimo"){ }
        public PasswordInvalidoLargoException(string message) : base(message) { }

    }
}
