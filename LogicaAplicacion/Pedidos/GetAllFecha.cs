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
    public class GetAllFecha : IObtenerFecha<PedidoDto>
    {
        IRepositorioPedido _repositorioPedido;

        public GetAllFecha(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }


        public IEnumerable<PedidoDto> Ejecutar(DateTime fecha)
        {
            IEnumerable<PedidoDto> pedidoDtos = PedidoMapper.ToListaDto(_repositorioPedido.GetAllFecha(fecha));
            return pedidoDtos; ;
        }
    }
}
