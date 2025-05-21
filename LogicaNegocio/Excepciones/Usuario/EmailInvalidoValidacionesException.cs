using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class EmailInvalidoValidacionesException : UsuarioException
    {
        public EmailInvalidoValidacionesException() : base("El email no cumple con los estandares de un email") { }
    }
}
