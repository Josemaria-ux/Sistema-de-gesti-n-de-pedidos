using Infraestructura.LogicaAccesoDatos.EF;
using LogicaAplicacion.Dtos.Articulos;
using LogicaAplicacion.Dtos.Lineas;
using LogicaAplicacion.Dtos.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Pedido;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.MapeosDto
{
    public class PedidoMapper
    {
        public static Pedido FromDto(PedidoDto pedidoDto)
        {
            if (pedidoDto.Discriminador.Equals("Comun")){
                return new Comun()
                {
             
                    FechaPedido = new FPedido(pedidoDto.FPedido, pedidoDto.FEntrega,"Comun"),
                    CostoTotal = pedidoDto.CostoTotal,
                    Anulado = pedidoDto.Anulado,
                    Entregado = pedidoDto.Entregado,
                };

            }
            if (pedidoDto.Discriminador.Equals("Express"))
            {
                return new Express()
                {
                    FechaPedido = new FPedido(pedidoDto.FPedido, pedidoDto.FEntrega, "Express"),
                    CostoTotal = pedidoDto.CostoTotal,
                    Anulado = pedidoDto.Anulado,
                    Entregado = pedidoDto.Entregado

                };

            }

            throw new NotImplementedException();

        }

        public static PedidoDto ToDto(Pedido pedido)
        {
            PedidoDto unp = new PedidoDto()
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                FEntrega = pedido.FechaPedido.FechaEntrega,
                FPedido = pedido.FechaPedido.FechaPedido,
                CostoTotal = pedido.CostoTotal,
                Anulado = pedido.Anulado,
                Entregado = pedido.Entregado,
                Discriminador = pedido.Discriminator,
                Items = new List<LineaDto>()
            };
            if(pedido.Lineas!=null && pedido.Lineas.Count > 0)
            {
                foreach (var item in pedido.Lineas)
                {
                    unp.Items.Add(LineaMapper.ToDto(item));
                }
            }
          
            return unp;
        }

        public static IEnumerable<PedidoDto> ToListaDto(IEnumerable<Pedido> pedidos)
        {
            List<PedidoDto> aux = new List<PedidoDto>();
            foreach (var pedido in pedidos)
            {
                PedidoDto pedidoDto = PedidoMapper.ToDto(pedido);
                aux.Add(pedidoDto);
            }
            return aux;
        }
    }
}

