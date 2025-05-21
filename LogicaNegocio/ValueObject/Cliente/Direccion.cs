using LogicaNegocio.Excepciones.Cliente;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Cliente
{
    public record Direccion
    {
        public string Calle { get; set; }

        public int Numero { get; set; }

        public string Ciudad { get; set; }

        public double Distancia { get; set; }

        public Direccion(string calle, int numero, string ciudad,double distancia)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
            Distancia = distancia;
            Validar();
        }

        public void Validar() {
            if (this.Calle.IsNullOrEmpty())
            {
                throw new CiudadInvalidaException();
            }
            if (this.Ciudad.IsNullOrEmpty())
            {
                throw new CalleInvalidaException();
            }
            if (this.Numero == null || this.Numero <= 0)
    {
                throw new NumeroInvalidoException();
            }
            if (this.Distancia == null || this.Distancia <= 0)
    {
                throw new CalleInvalidaException("La Distancia se debe indicar");
            }
        }
    }
}
