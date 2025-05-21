using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
namespace LogicaAplicacion.Pedidos
{
    public class EditarPedido : IEditar<PedidoDto>
    {
        IRepositorioPedido _repoPedido;

        public EditarPedido(IRepositorioPedido repoPedido)
        {
            _repoPedido = repoPedido;
        }

        public void Ejecutar(int id, PedidoDto obj)
        {
            Pedido pedido = PedidoMapper.FromDto(obj);
            _repoPedido.Update(id, pedido);
        }
    }
}

