using LogicaNegocio.ValueObject.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Normal : Usuario
    {
        public const string RolValor = "Normal";
        public Normal(string emai, string nom, string ape, string pass, bool eliminado) : base( emai,  nom,  ape,  pass,  eliminado)
        {
        }

        public Normal()
        {
            this.Discriminator = Admin.RolValor;
        }
    }
}
