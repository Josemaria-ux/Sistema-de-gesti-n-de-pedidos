using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.Articulo;


namespace LogicaNegocio.ValueObject
{
    public abstract record Nombre
    {
        public string Name { get;}

        public Nombre(string nom) { 
            Name = nom;
        }

        public Nombre()
        {
        }

        public abstract void Validar();

    }
}
