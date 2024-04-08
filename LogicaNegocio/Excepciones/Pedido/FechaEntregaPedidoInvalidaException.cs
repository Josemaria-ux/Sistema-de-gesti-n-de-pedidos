using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class FechaEntregaPedidoInvalidaException : PedidoException
    {
        public FechaEntregaPedidoInvalidaException() : base("La fecha de la entrega es invalida.")
        {

        }
    }
}
