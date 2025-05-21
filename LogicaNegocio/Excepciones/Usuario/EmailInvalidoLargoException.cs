using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class EmailInvalidoLargoException : UsuarioException
    {
        public EmailInvalidoLargoException() : base("El email es demasiado corto, debe tener minimo 5 caracteres") { }
        public EmailInvalidoLargoException(string message) : base(message) { }


    }
}
