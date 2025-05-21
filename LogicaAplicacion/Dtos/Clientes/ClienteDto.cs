using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.Clientes
{
    public record ClienteDto (int Id, string razonSocial, string rut, string calle, int numero, string ciudad,double distancia)
    {
    }
}
