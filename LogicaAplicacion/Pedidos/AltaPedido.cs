using LogicaAplicacion.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;

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
