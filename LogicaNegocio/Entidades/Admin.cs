using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Admin : Usuario
    {
        public const string RolValor = "Admin";

        public Admin(string emai, string nom, string ape, string pass, bool eliminado) : base(emai, nom, ape, pass, eliminado)
        {
        }

        public Admin()
        {
            this.Discriminator = Admin.RolValor;
        }
    }
}
