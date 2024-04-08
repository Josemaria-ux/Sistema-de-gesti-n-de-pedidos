using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;


namespace LogicaNegocio.Entidades
{
    public class Articulo : IEntity, IValidable
    {
        public int Id { get; set; }

        public NombreArticulo Nombre { get; set; }

        public string Descipcion { get; set; }

        public CodigoBarras CodigoBarras { get; set; }

        public Precio Precio { get; set; }

        public int Stock { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
