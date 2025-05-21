using LogicaNegocio.Excepciones.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Cliente
{
    public record RUT
    {
        public string Value { get; set; }

        public RUT(string r)
        {
            this.Value = r;
            Validar();
        }

        public RUT()
        {
        }

        public void Validar() {
            if (Value.Length != 12)
            {
                throw new LargoDelRUTInvalidoException();
            }
        }
    }
}
