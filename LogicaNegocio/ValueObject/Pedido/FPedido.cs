using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record FPedido
    {
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public static int plazoComun { get; set; }
        public static int plazoExpress { get; set; }

        public string Discriminador { get; set; }

        public FPedido(DateTime FechaPedido, DateTime FechaEntrega, string discriminador)
        {
            this.FechaPedido = FechaPedido;
            this.FechaEntrega = FechaEntrega;
            this.Discriminador = discriminador;
            Validar();
        }

        public FPedido() { }

        public void Validar()
        {
            ValidarFPedido();
            ValidarFEntrega();
        }

        public void ValidarFPedido()
        {
            if (this.FechaPedido.DayOfYear < DateTime.Now.DayOfYear)
            {
                throw new FechaPedidoPedidoInvalidoException("La fecha no puede ser anterior a la actual");
            }

            
        }

        public void ValidarFEntrega()
        {
            TimeSpan difFechas = this.FechaEntrega - this.FechaPedido;

            int days = (int)difFechas.TotalDays;
            if (this.FechaEntrega.DayOfYear < DateTime.Now.DayOfYear)
            {
                throw new FechaEntregaPedidoInvalidaException("La fecha no puede ser anterior a la actual");
            }
            if (this.Discriminador.Equals("Express") && days > plazoExpress)
            {
                throw new FechaEntregaPedidoInvalidaException("La entrega no puede superar los 5 dias");
            }
            if (this.Discriminador.Equals("Comun") && days < plazoComun)
            {
                throw new FechaEntregaPedidoInvalidaException("Si el pedido es comun la fecha de entrega debe tener de diferencia al menos una semana");
            }
        }
    }
}
