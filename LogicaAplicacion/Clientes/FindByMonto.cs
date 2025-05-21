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
    public class FindByMonto : IFindByMonto<ClienteDto>
    {
        IRepositorioCliente _repoCliente;

        public FindByMonto()
        {
        }

        public FindByMonto(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public IEnumerable<ClienteDto> Ejecutar(double monto)
        {

            IEnumerable<ClienteDto> clientesDtos = ClienteMapper.ToListaDto(_repoCliente.GetByMonto(monto));
            return clientesDtos;
        }
    }
}
