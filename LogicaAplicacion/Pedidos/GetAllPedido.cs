using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Pedidos
{
    public class GetAllPedido : IObtenerTodos<PedidoDto>
    {
        IRepositorioPedido _repositorioPedido;

        public GetAllPedido(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public IEnumerable<PedidoDto> Ejecutar()
        {
            IEnumerable<PedidoDto> pedidoDtos = PedidoMapper.ToListaDto(_repositorioPedido.GetAll());
            return pedidoDtos; ;
        }

    }
}
