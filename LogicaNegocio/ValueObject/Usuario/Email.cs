using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Usuario
{
    public record Email
    {
        public string Value { get; }

        public Email(string e)
        {
            Value = e;
            Validar();
        }
        public Email()
        {
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(this.Value))
            {
                throw new EmailInvalidoVacioException();
            }
            if (Value.Length < 5)
            {
                throw new EmailInvalidoLargoException();
            }
            if (!IsValidEmail(this.Value))
            {
                throw new EmailInvalidoValidacionesException();
            }
        }

        private static bool IsValidEmail(string address)
        {
            // Expresión regular para validar el formato de un email
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(address, emailRegex);
        }
    }
}
