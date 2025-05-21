using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.Articulos
{
    public record ArticuloDto(int Id, string Nombre, string Descripcion, string CodigoBarras, double Precio, int Stock, bool Eliminado) : IComparable<ArticuloDto>
    {
        public int CompareTo(ArticuloDto? other)
        {
            return this.Nombre.CompareTo(other.Nombre);
        }
    }
}
