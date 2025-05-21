using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Express : Pedido
    {
        public Express( FPedido fechaPedido, double costoTotal, Cliente cliente) : base( fechaPedido, costoTotal, cliente)
        {
        }

        public Express()
        {
            Discriminator = "Express";
        }
    }
}
