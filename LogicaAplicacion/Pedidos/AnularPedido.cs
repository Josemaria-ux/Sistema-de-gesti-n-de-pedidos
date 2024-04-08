using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Pedidos
{
    public class AnularPedido 
    {
        IRepositorioPedido _repositorioPedido;

        public AnularPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }


        public void Ejecutar(int id)
        {
            _repositorioPedido.AnularPedido(id);
        }
    }
}
