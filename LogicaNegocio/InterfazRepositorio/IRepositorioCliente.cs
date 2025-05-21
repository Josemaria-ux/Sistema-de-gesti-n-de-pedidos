using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> GetByRazonSocial(string txt);

        public IEnumerable<Cliente> GetByMonto(double monto);
    }
}
