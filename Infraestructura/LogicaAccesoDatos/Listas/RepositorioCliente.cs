using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.Listas
{
    public class RepositorioCliente : IRepositorioCliente
    {

        private static List<Cliente> _clientes = new List<Cliente>();

        public void Add(Cliente obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            _clientes.Add(obj);
        }

        public void Delete(int id)
        {
            Cliente cliente = GetById(id);
            if (cliente == null)
            {
                throw new NotFoundException();
            }
            _clientes.Remove(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clientes;
        }

        public Cliente GetById(int id)
        {
            foreach (var item in _clientes)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Cliente> GetByNameOrLastName(string txt)
        {
            List<Cliente> res = new List<Cliente>();

            foreach (var cliente in _clientes)
            {
                //Ver el tema del nombre o apellido, puede tenerlo el cliente o simplemente heredar de usuario.
                if (cliente.RazonSocial == txt)
                {
                    res.Add(cliente);
                }
            }
            return res;
        }

        public IEnumerable<Cliente> GetByMonto(double monto)
        {
            if (monto < 0)
            {
                throw new ArgumentException("Ingresar valores mayores o igual a 0");
            }
            List<Cliente> res = new List<Cliente>();

            foreach (var cliente in _clientes)
            {
                foreach (var pedido in cliente.pedidos)
                {
                    if (pedido.CostoTotal >= monto)
                    {
                        res.Add(cliente);
                        break;
                    }
                }
            }
            return res;
        }

        public void Update(int id, Cliente obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetByName(string txt)
        {
            throw new NotImplementedException();
        }
    }
}
