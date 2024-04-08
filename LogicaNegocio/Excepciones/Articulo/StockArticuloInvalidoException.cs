using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    internal class StockArticuloInvalidoException : ArticuloException
    {
        public StockArticuloInvalidoException() : base("El stock del articulo es invalido.")
        {

        }
    }
}
