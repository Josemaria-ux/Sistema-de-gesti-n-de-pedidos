using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class NombreUsuarioInvalidoException : UsuarioException
    {
        public NombreUsuarioInvalidoException(): base("El nombre tiene que tener como minimo 2 caracteres"){ }
    }
}
