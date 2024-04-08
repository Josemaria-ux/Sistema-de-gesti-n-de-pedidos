using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Linea
    {

        public Articulo Articulo { get; set; }

        public int Unidades { get; set; }

        public Precio Precio { get; set; }

        
    }
}
