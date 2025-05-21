using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject.Cliente;
namespace LogicaNegocio.Entidades
{
    public class Cliente : IEntity, IValidable
    {
        public int Id { get; set;}

        public string RazonSocial { get; set;}  

        public RUT RUT { get; set;}

        public Direccion Direccion { get; set;}

        public List<Pedido> pedidos { get; set;} 

        public void Validar()
        {
            if (RazonSocial.Length == 13)
            {
                throw new LargoDelRUTInvalidoException();
            }
        }
    }
}
