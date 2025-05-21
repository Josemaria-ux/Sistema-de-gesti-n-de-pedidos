using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Clientes
{
    public class GetAllClientes : IObtenerTodos<ClienteDto>
    {
        IRepositorioCliente _repoCliente;

        public GetAllClientes(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }

        public IEnumerable<ClienteDto> Ejecutar()
        {
            IEnumerable<ClienteDto> clientesDtos = ClienteMapper.ToListaDto(_repoCliente.GetAll());
            return clientesDtos;
        }
    }
}
