using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Comun : Pedido
    {
        public Comun( FPedido fechaPedido, double costoTotal, Cliente cliente) : base( fechaPedido, costoTotal, cliente)
        {
        }

        public Comun()
        {
            Discriminator = "Comun";
        }

    }
}
