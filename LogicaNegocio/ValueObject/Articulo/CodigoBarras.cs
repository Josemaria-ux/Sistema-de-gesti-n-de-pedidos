using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.InterfazRepositorio;

namespace LogicaNegocio.ValueObject
{
    public record CodigoBarras
    {
        public string Value { get; set; }

        public CodigoBarras(string cod)
        {
            Value = cod;
            Validar();
        }

        public CodigoBarras()
        {
        }

        public void Validar() 
        {
            if (string.IsNullOrEmpty(this.Value)) 
            {
                throw new CodigoArticuloInvalidoException();
            }
            if (Value.Length != 13) 
            {
            throw new CodigoArticuloInvalidoException("El codigo de barras debe tener 13 digitos");
            }
        }
    }
}
