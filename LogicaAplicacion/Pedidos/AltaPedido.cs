using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Pedidos
{
    public class AltaPedido : IAlta<Pedido>
    {
        IRepositorioPedido _repositorioPedido;

        public AltaPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void Ejecutar(Pedido pedido)
        {
            _repositorioPedido.Add(pedido);
        }
    }
}
