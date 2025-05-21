using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.Lineas
{
    public record LineaDto
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public string ArticuloNombre { get; set; }
        public int Unidades { get; set; }
        public double Precio { get; set; }
        public int IdPedido { get; set; }
    }

    //public record LineaDto(int Id, string ArticuloCB, string ArticuloNombre, int Unidades, double Precio, int IdPedido)
    //{
    //}
}
