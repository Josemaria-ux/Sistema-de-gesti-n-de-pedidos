using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;


namespace LogicaAplicacion.Pedidos
{
    public class GetByIdPedido : IObtener<PedidoDto>
    {
        IRepositorioPedido _repoPedido;

        public GetByIdPedido(IRepositorioPedido repoPedido)
        {
            _repoPedido = repoPedido;
        }
        public PedidoDto Ejecutar(int Id)
        {
            Pedido pedido = _repoPedido.GetById(Id);
            PedidoDto pedidoDto = PedidoMapper.ToDto(pedido);
            return pedidoDto;
        }
    }
}
