using LogicaNegocio.IntefacesDominio;
using LogicaNegocio.ValueObject.Usuario;

namespace LogicaNegocio.Entidades
{
    public abstract class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }

        public Email Email { get; set; }

        public NombreUsuario NombreCompleto { get; set; }

        public Password Password { get; set; }

        public string PassHash { get; set; }


        public Cliente? cliente { get; set; }

        public string Discriminator { get; set; }

        public bool Eliminado { get; set; }

        public Usuario() { 
            Eliminado = false;
        }

        public Usuario(string emai, string nom, string ape, string pass, bool eliminado)
        {
            this.Email = new Email(emai);
            this.NombreCompleto = new NombreUsuario(nom, ape);
            this.Password = new Password(pass);
            this.Eliminado = eliminado;
        }

        public void Validar() { 
           
        }

        public void Update(Usuario obj) { 
            obj.Validar();
            this.Email = obj.Email;
            this.NombreCompleto = obj.NombreCompleto;
            this.Password = obj.Password;
            this.cliente = obj.cliente;
            HashPassword();
        }

        public void HashPassword()
        {
            PassHash = BCrypt.Net.BCrypt.HashPassword(this.Password.Value);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


    }

}
