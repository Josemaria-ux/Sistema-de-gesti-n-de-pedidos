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
    public class FindByMonto : IFindByMonto<Cliente>
    {
        IRepositorioCliente _repoCliente;

        public FindByMonto()
        {
        }

        public FindByMonto(IRepositorioCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }
        public IEnumerable<Cliente> Ejecutar(double monto)
        {
            return _repoCliente.GetByMonto(monto);   
        }
    }
}
