﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class UsuarioException: DomainException
    {
        public UsuarioException(string message) : base(message) { }
        public UsuarioException() : base("Hubo un problema con el usuario") { }
    }
}
