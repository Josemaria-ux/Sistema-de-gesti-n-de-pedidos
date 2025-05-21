using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class PasswordInvalidoValidacionesException : UsuarioException
    {
        public PasswordInvalidoValidacionesException() : base("La contraseña es invalida, tiene que tener por lo menos una letra mayus, una minus, y minimo un signo") { }
    }
}
