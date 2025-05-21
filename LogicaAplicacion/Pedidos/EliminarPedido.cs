using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;

namespace LogicaAplicacion.Pedidos
{
    public class EliminarPedido : IEliminar<PedidoDto>
    {
        IRepositorioPedido _repositorioPedido;

        public EliminarPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }


        public void Ejecutar(int id)
        {
            _repositorioPedido.Delete(id);
        }
    }
}
