using LogicaAplicacion.Dtos.Lineas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.Pedidos
{
    //todo : Como comunico Linea con Pedido?
    public record PedidoDto()
    {
        public int Id { get; set; }
        public string Discriminador { get; set; }
        public bool Entregado { get; set; } = false;
        public bool Anulado { get; set; } = false ;
        public int ClienteId { get; set; }
        public int Unudades { get; set; }
        public DateTime FPedido { get; set; }
        public DateTime FEntrega { get; set; }
        public double CostoTotal { get; set; }
        public IList<LineaDto> Items { get; set; } = new List<LineaDto>();
        



    }
}
