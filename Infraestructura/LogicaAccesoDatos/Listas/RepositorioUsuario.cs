using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.Listas
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        public void Add(Usuario obj)
        {
            _usuarios.Add(obj);
        }

        public void Delete(int id)
        {
            Usuario user = GetById(id);
            if (user == null)
            {
                throw new NotFoundException();
            }
            _usuarios.Remove(user);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarios;
        }

        public Usuario GetById(int id)
        {
            foreach (var item in _usuarios)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Update(int id, Usuario obj)
        {
            Usuario usuario = GetById(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            usuario.Update(obj);
        }
    }
}
