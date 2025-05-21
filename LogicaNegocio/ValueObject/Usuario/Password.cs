using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Usuario
{
    public record Password
    {
        public string Value { get; }

        public Password(string pass)
        {
            Value = pass;
            Validar();
        }

        public Password() {
        }

        public void Validar()
        {
            ValidarLargo();
            if (!ValidarRequisitos())
            {
                throw new PasswordInvalidoValidacionesException();
            }
        }

        public void ValidarLargo()
        {
            if (string.IsNullOrEmpty(Value) || Value.Length < 5)
            {
                throw new PasswordInvalidoLargoException();
            }
        }

        public bool ValidarRequisitos()
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.;,!]).{6,}$";
            return Regex.IsMatch(this.Value, pattern);
        }
    }
}
