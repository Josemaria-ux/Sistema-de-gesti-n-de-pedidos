﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazServicios
{
    public interface IAlta<T>
    {
        void Ejecutar(T obj);
    }
}
