using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record NombreUsuario : Nombre
    {
        public string Apellido {  get;}

        public NombreUsuario(string nom, string ape) : base(nom)
        {
            this.Apellido = ape;
            Validar();
        }

        public override void Validar()
        {
            ValidarNombre();
            ValidarApellido();
        }

        public void ValidarApellido() {
            if (string.IsNullOrEmpty(this.Name) || this.Name.Length < 2)
            {
                throw new NombreUsuarioInvalidoException();
            }
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(this.Apellido) || this.Apellido.Length < 2)
            {
                throw new  ApellidoUsuarioInvalidoException();
            }
        }
    }
}
