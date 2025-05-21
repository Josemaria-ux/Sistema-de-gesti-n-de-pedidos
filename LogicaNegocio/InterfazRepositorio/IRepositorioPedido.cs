using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        IEnumerable<Pedido> GetAllFecha(DateTime fecha);
        public IEnumerable<Pedido> GetPedidosAnulados();
    }
}
