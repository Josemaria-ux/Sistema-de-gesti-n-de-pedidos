using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private static PedidoContext _context;

        public RepositorioCliente(PedidoContext context)
        {
            _context = context;
        }
        public void Add(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.AsEnumerable().ToList();
        }

        public Cliente GetById(int id)
        {
            Cliente unC= _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            return unC;
        }

        public IEnumerable<Cliente> GetByMonto(double monto)
        {
            var clientes = _context.Clientes
                .Where(cli =>
                        cli.pedidos
                        .Any(ped => ped.CostoTotal >= monto));
            return clientes.ToList();
        }

        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Cliente> IRepositorioCliente.GetByRazonSocial(string txt)
        {
            var clientes = _context.Clientes.Where(cli => cli.RazonSocial.Contains(txt));
            return clientes.ToList();
        }
    }
}
