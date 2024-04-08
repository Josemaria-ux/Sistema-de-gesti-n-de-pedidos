using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record NombreArticulo : Nombre
    {
        public NombreArticulo(string original) : base(original)
        {
            Validar();
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(this.Name) || this.Name.Length < 2)
            {
                throw new NombreArticuloInvalidoException();
            }
        }
    }
}
