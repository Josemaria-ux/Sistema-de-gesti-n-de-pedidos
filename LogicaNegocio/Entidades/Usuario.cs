using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }

        public Email Email { get; set; }

        public NombreUsuario NombreCompleto { get; set; }

        public Password Password { get; set; }

        public Cliente? cliente { get; set; }

        public Usuario() { }

        public void Validar() { 
        
        }

        public void Update(Usuario obj) { 
            obj.Validar();
            this.Email = obj.Email;
            this.NombreCompleto = obj.NombreCompleto;
            this.Password = obj.Password;
            this.cliente = obj.cliente;
        }


    }

}
