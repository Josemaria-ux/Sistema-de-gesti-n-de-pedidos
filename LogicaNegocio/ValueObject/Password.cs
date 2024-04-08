using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record Password
    {
        public string Value { get; }

        public Password(string pass) {
            Value = pass;
            Validar();
        }

        public void Validar() { 
            ValidarLargo();
            ValidarRequisitos();
        }

        public void ValidarLargo() {
            if (string.IsNullOrEmpty(this.Value) || this.Value.Length < 5)
            {
                throw new Exception();
            }
        }

        public void ValidarRequisitos()
        {

        }
    }
}
