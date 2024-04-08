using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class DescripcionArticuloInavlidoException : ArticuloException
    {
        public DescripcionArticuloInavlidoException() : base("El nombre del articulo es invalido.")
        {

        }
    }
}
