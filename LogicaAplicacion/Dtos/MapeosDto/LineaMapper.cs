using LogicaAplicacion.Articulos;
using LogicaAplicacion.Dtos.Lineas;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.MapeosDto
{
    public class LineaMapper
    {
        public static Linea FromDto(LineaDto lineaDto)
        {
                return new Linea()
                {
                    Id = lineaDto.Id,
                    ArticuloId = lineaDto.ArticuloId,
                    Unidades = lineaDto.Unidades,
                    IdPedido = lineaDto.IdPedido,
                    Precio = new Precio(lineaDto.Precio)
                };
            throw new NotImplementedException();

        }

        public static LineaDto ToDto(Linea linea)
        {
            return new LineaDto()
            {
                Id = linea.Id,
                ArticuloId = linea.ArticuloId,
                Unidades = linea.Unidades,
                IdPedido = linea.IdPedido,
                Precio = linea.Precio.Value
            };
        }

        public static IEnumerable<LineaDto> ToListaDto(IEnumerable<Linea> linea)
        {
            List<LineaDto> aux = new List<LineaDto>();
            foreach (var unaL in linea)
            {
                LineaDto lineaDto = LineaMapper.ToDto(unaL);
                aux.Add(lineaDto);
            }
            return aux;
        }
    }
}
