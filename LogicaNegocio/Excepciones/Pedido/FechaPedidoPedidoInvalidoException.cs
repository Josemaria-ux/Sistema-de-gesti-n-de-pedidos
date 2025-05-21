using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class FechaPedidoPedidoInvalidoException : PedidoException
    {
        public FechaPedidoPedidoInvalidoException() : base("La fecha del pedido es invalida.")
        {

        }
        public FechaPedidoPedidoInvalidoException(string msg) : base(msg)
        {

        }
    }
}
