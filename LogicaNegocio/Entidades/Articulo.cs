using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.Excepciones;

using LogicaNegocio.Excepciones.Articulo;
namespace LogicaNegocio.Entidades
{
    public class Articulo : IEntity, IValidable, IComparable<Articulo>
    {
        public int Id { get; set; }

        public NombreArticulo Nombre { get; set; }

        public string Descripcion { get; set; }

        public CodigoBarras CodigoBarras { get; set; }

        public Precio Precio { get; set; }

        public int Stock { get; set; }

        public bool Eliminado { get; set; }


        public Articulo(NombreArticulo nombre, string descipcion, CodigoBarras codigoBarras, Precio precio, int stock)
        {
            Nombre = nombre;
            Descripcion = descipcion;
            CodigoBarras = codigoBarras;
            Precio = precio;
            Stock = stock;
            Eliminado = false;
        }

        public Articulo()
        {
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarCodigoBarras();
            ValidarPrecio();
            ValidarStock();
        }

        private void ValidarStock()
        {
            if(Stock == null)
            {
                throw new StockArticuloInvalidoException("El stock no puede ser null");
            }
            if(Stock < 0) 
            {
                throw new StockArticuloInvalidoException("No puedes tener un stock negativo");
            }
        }

        private void ValidarPrecio()
        {
            if(Precio == null)
            {
                throw new PrecioArticuloInvalidoException("El precio no puede ser null");
            }
        }

        private void ValidarCodigoBarras()
        {
            if (CodigoBarras == null)
            {
                throw new CodigoArticuloInvalidoException("El codigo de barras no puede ser null");
            }
        }

        private void ValidarDescripcion()
        {
            if(Descripcion == null)
            {
                throw new DescripcionArticuloInavlidoException("La descripción no puede ser null");
            }
            if (Descripcion.Length < 6)
            {
                throw new DescripcionArticuloInavlidoException("La descripción debe tener minimo 6 caracteres");
            }
        }

        private void ValidarNombre()
        {
            if(Nombre == null)
            {
                throw new NombreArticuloInvalidoException("El nombre no puede ser null");
            }
        }

        public void Update(Articulo obj)
        {
            obj.Validar();
            this.Nombre = obj.Nombre;
            this.Descripcion = obj.Descripcion;
            this.CodigoBarras = obj.CodigoBarras;
            this.Precio = obj.Precio;
            this.Stock = obj.Stock;
        }

        public void Delete()
        {
            this.Eliminado = true;
        }


        public int CompareTo(Articulo? unA)
        {
            return this.Nombre.Name.CompareTo(unA.Nombre.Name);
        }
    }
}
