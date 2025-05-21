using LogicaNegocio.Excepciones.Linea;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.Excepciones.Pedido;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido : IEntity, IValidable,IComparable<Pedido>
    {

        public int Id { get; set; }

        public required FPedido FechaPedido { get; set; }

        public double CostoTotal { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public IList<Linea> Lineas { get; set; }

        public bool Entregado { get; set; }

        public bool Anulado { get; set; }

        public static double IVA { get; set; }

        public static double RecargoExpress {  get; set; }

        public static double REntregaDia { get; set; }

        public static double RecargoDistancia { get; set; }

        public string Discriminator { get; set; }
        public Pedido(FPedido fechaPedido, double costoTotal, Cliente cliente)
        {
            FechaPedido = fechaPedido;
            CostoTotal = costoTotal;
            Cliente = cliente;
            Entregado = false;
            Anulado = false;
        }

        public Pedido(FPedido fechaPedido, double costoTotal, int cliente)
        {
            FechaPedido = fechaPedido;
            CostoTotal = costoTotal;
            Entregado = false;
            Anulado = false;
        }

        public Pedido()
        {

        }


        public void Validar()
        {
            ValidarFPedido();
            ValidarCliente();
            ValidarLinea();
            CalcularCostoTotal(); 

        }

        private void ValidarCliente()
        {
            if (this.Cliente == null)
            {
                throw new LineaException();
            }
        }

        private void ValidarLinea()
        {
            if(this.Lineas == null)
            {
                throw new LineaException();
            }
        }


        protected virtual void ValidarFPedido()
        {
            if(FechaPedido == null)
            {
                throw new FechaPedidoPedidoInvalidoException();
            }
        }



        public void Update(Pedido obj)
        {
            this.FechaPedido = obj.FechaPedido;
            this.Lineas = obj.Lineas;
            this.CostoTotal = obj.CostoTotal;
        }

        public void Delete()
        {
            this.Anulado = true;
        }




        public virtual void AgregarRecarga()
        {
            if (this.Discriminator.Equals("Express"))
            {
                CostoTotal += (CostoTotal * RecargoExpress) / 100;
                if (this.FechaPedido.FechaPedido.Date.AddDays(1).Equals(FechaPedido.FechaEntrega.Date))
                {
                    CostoTotal += (CostoTotal * REntregaDia) / 100;
                }
            }
            if (this.Discriminator.Equals("Comun") && this.Cliente.Direccion.Distancia > 100)
            {
                CostoTotal += (CostoTotal * RecargoDistancia) / 100;
            }
            AgregarIVA();

        }

        private void AgregarIVA()
        {
            CostoTotal += ((CostoTotal * IVA) / 100);
        }

     

        public void CalcularCostoTotal()
        {
            CostoTotal = 0;
            foreach (Linea unaL in Lineas)
            {
                CostoTotal += unaL.CalcularCosto();
            }

            AgregarRecarga();
            CostoTotal = Math.Round(CostoTotal,2);
        }

        public int CompareTo(Pedido? obj)
        {
            return obj.FechaPedido.FechaPedido.CompareTo(this.FechaPedido.FechaPedido);
        }
    }
}
