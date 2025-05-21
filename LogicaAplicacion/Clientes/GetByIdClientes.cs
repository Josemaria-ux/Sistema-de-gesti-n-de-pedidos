using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Clientes
{
    public class GetByIdCliente : IObtener<ClienteDto>
    {
        IRepositorioCliente _repoCliente;

        public GetByIdCliente(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public ClienteDto Ejecutar(int Id)
        {
            Cliente cli = _repoCliente.GetById(Id);
            if (cli == null)
            {
                throw new ClienteException("No se encontro el Cliente.");
            }
            ClienteDto clienteDto = ClienteMapper.ToDto(cli);
            return clienteDto;
        }
    }
}
