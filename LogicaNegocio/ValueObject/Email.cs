using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record Email
    {
        public string Value { get; }

        public Email(string e){
            Value = e;
            Validar();
        }

        public void Validar() { 
            if (string.IsNullOrEmpty(Value))
            {
                throw new EmailInvalidoVacioException();
            }
            if (Value.Length < 5)
            {
                throw new EmailInvalidoLargoException();
            }
        }
    }
}
