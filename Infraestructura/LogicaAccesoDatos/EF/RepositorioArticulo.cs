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
    public class RepositorioArticulo : IRepositorioArticulo
    {

        private PedidoContext _context;

        public RepositorioArticulo(PedidoContext context)
        {
            _context = context;
        }

        public void Add(Articulo obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            obj.Validar();
            Articulo pruebaName = _context.Articulos.FirstOrDefault(articulo => articulo.Nombre.Name == obj.Nombre.Name);
            Articulo pruebaCodeBarras = _context.Articulos.FirstOrDefault(articulo => articulo.CodigoBarras.Value == obj.CodigoBarras.Value);
            if (pruebaName != null)
            {
                throw new ArgumentException("Este Nombre de Articulo ya existe");
            }
            if (pruebaCodeBarras != null)
            {
                throw new ArgumentException("Este Codigo de Barras de Articulo ya existe");
            }
            _context.Articulos.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Articulo articulo = GetById(id);
            if (articulo == null)
            {
                throw new NotFoundException();
            }
            articulo.Delete();
            _context.Articulos.Update(articulo);
            _context.SaveChanges(true);
        }

        public IEnumerable<Articulo> GetAll()
        {
            var articulos = _context.Articulos
       .Where(art => !art.Eliminado);

            return articulos.ToList();
        }

        public Articulo GetById(int id)
        {
            return _context.Articulos.FirstOrDefault(articulo => articulo.Id == id);
        }

        public Articulo GetByCB(string id)
        {
            return _context.Articulos.FirstOrDefault(articulo => articulo.CodigoBarras.Value == id);
        }



        public void Update(int id, Articulo obj)
        {
            Articulo articulo = GetById(id);
            if (articulo == null)
            {
                throw new NotFoundException();
            }
            articulo.Update(obj);
            _context.Articulos.Update(articulo);
            _context.SaveChanges(true);
        }
    }
}
