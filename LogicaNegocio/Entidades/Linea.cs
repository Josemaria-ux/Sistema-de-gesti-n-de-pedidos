using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.Excepciones.Linea;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Linea : IEntity, IValidable
    {
        public int Id { get; set; } 
        public Articulo Articulo { get; set; }
        public int ArticuloId { get; set; }

        public int Unidades { get; set; }

        public Precio Precio { get; set; }

        public int IdPedido { get; set; }

        public void Validar()
        {
            ValidarArticulo();
            ValidarUnidades();
            ValidarPrecio();
        }

        private void ValidarPrecio()
        {
            if (Precio == null) 
            {
                throw new PrecioException("El precio no puede ser null");
            }
        }

        private void ValidarUnidades()
        {
            if(Unidades == null)
            {
                new UnidadInvalidaException();
            }
            if(Unidades < 0)
            {
                throw new UnidadInvalidaException("Las unidades no pueden ser negativas");
            }

            if (Unidades > Articulo.Stock)
            {
                throw new UnidadInvalidaException("No hay suficiente stock");
            }
        }

        private void ValidarArticulo()
        {
            if(Articulo == null)
            {
                throw new ArticuloException("El articulo no puede ser null");
            }
        }

        public double CalcularCosto()
        {
            return Precio.Value * Unidades;
        }
    }
}
