using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;
namespace LogicaNegocio.Entidades
{
    public abstract class Pedido : IEntity, IValidable
    {
        public int Id { get; set; }

        public required FEntrega FechaEntrega { get; set; }

        public required FPedido FechaPedido { get; set; }

        public double CostoTotal { get; set; }

        public Cliente Cliente { get; set; }

        public Linea Linea { get; set; }

        public bool Entregado { get; set; }

        public bool Anulado { get; set; }

        public static double IVA { get; set; }

        public virtual void VerificarFechaEntrega()
        {

        }

        public virtual void AgregarRecarga()
        {

        }

        private void AgregarIVA()
        {

        }

        public void Validar()
        {
            throw new NotImplementedException();
        }

        public double CalcularCostoTotal()
        {
            // Crear funcion CalcularCostoTotal para realizar busquedas de cliente(Depende del CalcularPrecio en Linea).
            throw new NotImplementedException();
        
        }
    }
}
