using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record RUT
    {
        public string rut {  get; set; }

        public RUT(string r)
        {
            this.rut = r;
            Validar();
        }

        public void Validar() { }
    }
}
