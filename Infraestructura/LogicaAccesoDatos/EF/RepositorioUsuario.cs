using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private PedidoContext _context;

        public RepositorioUsuario (PedidoContext context)
        {
            _context = context;
        }

        public void Add(Usuario obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            try
            {
                obj.Validar();
                obj.Id = 0;
                obj.HashPassword();
                _context.Usuarios.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Delete(int id)
        {
            Usuario user = GetById(id);
            if (user == null)
            {
                throw new NotFoundException();
            }
            Usuario userCopia = user;
            userCopia.Eliminado = true;
            Update(id, userCopia);
            //_context.Usuarios.Remove(user);
            //_context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = _context.Usuarios
                .Where(user => !user.Eliminado);

            return usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(user => user.Id == id);
        }

        public void Update(int id, Usuario obj)
        {
            Usuario user = GetById(id);
            if (user == null)
            {
                throw new NotFoundException();
            }
            try
            {
                if (!user.Email.Value.Equals(obj.Email.Value))
                {
                    throw new ArgumentException("No se puede editar el Email");
                }
                user.Update(obj);
                user.HashPassword();
                user.Validar();
                _context.Usuarios.Update(user);
                _context.SaveChanges(true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario GetByLogin(string email, string pass)
        {
            Usuario unUser = _context.Usuarios
            .AsEnumerable()
            .FirstOrDefault(user => user.Email.Value == email && user.Password.Value == pass);
            return unUser;
        }
    }
}
