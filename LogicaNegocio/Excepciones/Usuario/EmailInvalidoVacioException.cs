using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class EmailInvalidoVacioException : UsuarioException
    {
        public EmailInvalidoVacioException() : base("El email no puede estar vacio") { }
        public EmailInvalidoVacioException(string message) : base(message) { }


    }
}
