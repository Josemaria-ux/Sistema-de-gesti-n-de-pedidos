﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class ArticuloException : DomainException
    {
        public ArticuloException(string message) : base(message) { }

        public ArticuloException() : base("El articulo es invalido") { }

    }
}

