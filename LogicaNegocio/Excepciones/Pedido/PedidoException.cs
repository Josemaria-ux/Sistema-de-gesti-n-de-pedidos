﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedido
{
    public class PedidoException : DomainException
    { 
        public PedidoException(string message) : base(message) { }

        public PedidoException() : base("Hubo un problema con el pedido") { }
    }
}
