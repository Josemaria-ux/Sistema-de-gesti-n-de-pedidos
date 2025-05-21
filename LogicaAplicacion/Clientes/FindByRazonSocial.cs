using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Clientes
{
    public class FindByRazonSocial : IFindByRazonSocial<ClienteDto>
    {
        IRepositorioCliente _repoCliente;

        public FindByRazonSocial()
        {
        }

        public FindByRazonSocial(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public IEnumerable<ClienteDto> Ejecutar(string rut)
        {
            IEnumerable<ClienteDto> clientesDtos = ClienteMapper.ToListaDto(_repoCliente.GetByRazonSocial(rut));
            return clientesDtos;
        }
    }
}
