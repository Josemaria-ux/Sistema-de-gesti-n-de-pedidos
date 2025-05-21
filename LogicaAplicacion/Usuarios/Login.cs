using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class Login : ILogin<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public Login(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public UsuarioDto Ejecutar(string Email, string Password)
        {
            Usuario user = _repoUsuario.GetByLogin(Email, Password);
            if (user == null)
            {
                throw new UsuarioException("usuario no encontrado");
            }
            UsuarioDto usuarioDto = UsuarioMapper.ToDto(user);
            return usuarioDto;
        }
    }
}
