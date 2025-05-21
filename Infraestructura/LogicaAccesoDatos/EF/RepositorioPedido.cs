using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Linea;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.Pedido;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private PedidoContext _context;

        public RepositorioPedido(PedidoContext context)
        {
            _context = context;
        }

        public void Add(Pedido obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullRepositorioException();
                }
                if (obj.Lineas == null || obj.Lineas.Count == 0)
                {
                    throw new LineaException("el pedido no puede no tener articulos");
                }
                Articulo articuloLinea;
                foreach (var item in obj.Lineas)
                {
                    item.Id = 0;
                    articuloLinea = _context.Articulos.FirstOrDefault(c => c.Id == item.ArticuloId);
                    item.Articulo =articuloLinea;
                    _context.Lineas.Update(item);
                }
     
                _context.SaveChanges();
                obj.Validar();
                obj.Cliente = _context.Clientes.FirstOrDefault(c => c.Id == obj.Cliente.Id);
               
                List<Linea> aux = new List<Linea>();
                foreach (var item in obj.Lineas)
                {
                    aux.Add(_context.Lineas.FirstOrDefault(c => c.Id == item.Id));
                    articuloLinea = _context.Articulos.FirstOrDefault(c => c.Id == item.ArticuloId);
                    if(articuloLinea.Stock < item.Unidades)
                    {
                        throw new StockArticuloInvalidoException("No hay stock suficiente");
                    }
                    articuloLinea.Stock -= item.Unidades;
                    _context.Articulos.Update(articuloLinea);
                    _context.SaveChanges();
                }
                obj.Lineas = aux;
                _context.Pedidos.Add(obj);
                _context.SaveChanges();
            }
            catch (PedidoException ex)
            {
                foreach (var item in obj.Lineas)
                {
                    item.Id = 0;
                    _context.Lineas.Remove(item);
                    _context.SaveChanges();
                }
                throw new Exception(ex.Message);
            }
        
        }

        public void Delete(int id)
        {
            Pedido pedido = GetById(id);
            if (pedido == null)
            {
                throw new NotFoundException();
            }
            if (pedido.Entregado)
            {
                throw new PedidoException("El pedido ya fue entregado");
            }


            Pedido unP= _context.Pedidos.Include(p => p.Lineas).FirstOrDefault(p => p.Id == id);
            foreach (var item in unP.Lineas)
            {
               Articulo a= _context.Articulos.FirstOrDefault((art => art.Id == item.ArticuloId));
                a.Stock += item.Unidades;
                _context.Articulos.Update(a);
               
                _context.SaveChanges();
            }
            var linea = _context.Lineas.Where(p => p.IdPedido == pedido.Id);
            _context.Lineas.RemoveRange(linea);
            unP.Anulado =true;
            Update(id, pedido);
        }

        public IEnumerable<Pedido> GetAll()
        {
            var pedidos = _context.Pedidos
                .Where(art => !art.Anulado).OrderByDescending(p => p.FechaPedido.FechaPedido);

            return pedidos.ToList();
        }

        public Pedido GetById(int id)
        {
            Pedido unP = _context.Pedidos.Include(p => p.Lineas).FirstOrDefault(p => p.Id == id);
            return unP;
        }

        public IEnumerable<Pedido> GetPedidosAnulados()
        {
            var pedidos = _context.Pedidos
            .Where(art => art.Anulado == true).OrderByDescending(p => p.FechaPedido.FechaPedido);

            return pedidos.ToList();
        }
        public IEnumerable<Pedido> GetAllFecha(DateTime fecha)
        {
            IEnumerable<Pedido> pedidos = _context.Pedidos
            .Where(art => art.FechaPedido.FechaPedido.Date.Equals(fecha.Date) && !art.Entregado).OrderByDescending(p => p.FechaPedido.FechaPedido);

            return pedidos.ToList();
        }

        public void Update(int id, Pedido obj)
        {
            Pedido pedido = GetById(id);
            if (pedido == null)
            {
                throw new NotFoundException();
            }
            pedido.Update(obj);
            _context.Pedidos.Update(pedido);
            _context.SaveChanges(true);
        }
    }
}
