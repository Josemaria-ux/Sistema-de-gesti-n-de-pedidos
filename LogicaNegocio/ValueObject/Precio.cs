using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.Articulo;

namespace LogicaNegocio.ValueObject
{
    public record Precio
    {

        public double Value { get; set; }

        public Precio(double p) {
            Value = p;
            Validar();
        }

        private void Validar() 
        {
        if( Value == null || Value < 0)
            {
                throw new PrecioArticuloInvalidoException();
            }

        }

    }
}
