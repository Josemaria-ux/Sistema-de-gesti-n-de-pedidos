using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObject.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.MapeosDto
{
    public class ClienteMapper
    {
        public static Cliente FromDto(ClienteDto clienteDto)
        {
            return new Cliente()
            {
                Id = clienteDto.Id,
                RazonSocial = clienteDto.razonSocial,
                RUT = new RUT(clienteDto.rut),
                Direccion = new Direccion(clienteDto.calle, clienteDto.numero, clienteDto.ciudad,clienteDto.distancia)
            };
        }

        public static ClienteDto ToDto(Cliente cliente)
        {
            return new ClienteDto(cliente.Id, cliente.RazonSocial, cliente.RUT.Value, cliente.Direccion.Calle, cliente.Direccion.Numero, cliente.Direccion.Ciudad,cliente.Direccion.Distancia);
        }

        public static IEnumerable<ClienteDto> ToListaDto(IEnumerable<Cliente> clientes)
        {
            List<ClienteDto> aux = new List<ClienteDto>();
            foreach (var cliente in clientes)
            {
                ClienteDto clienteDto = ClienteMapper.ToDto(cliente);
                aux.Add(clienteDto);
            }
            return aux;
        }
    }
}
