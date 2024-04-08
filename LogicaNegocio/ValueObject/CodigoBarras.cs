using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record CodigoBarras
    {
        public string codigoBarras { get; set; }

        public CodigoBarras(string cod)
        {
            codigoBarras = cod;
            Validar();
        }

        public void Validar() { }
    }
}
