using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.MapeosDto
{
    public class UsuarioMapper
    {
        public static Usuario FromDto(UsuarioDto usuarioDto)
        {
            if (usuarioDto.Discriminador == Admin.RolValor)
            {
                return new Admin()
                {
                    Email = new Email(usuarioDto.Email),
                    NombreCompleto = new NombreUsuario(usuarioDto.Nombre, usuarioDto.Apellido),
                    Password = new Password(usuarioDto.password),
                    PassHash = usuarioDto.passHash,
                    Eliminado = usuarioDto.Eliminado,
                    Discriminator = usuarioDto.Discriminador
                };
            }
            else
            {
                return new Normal()
                {
                    Email = new Email(usuarioDto.Email),
                    NombreCompleto = new NombreUsuario(usuarioDto.Nombre, usuarioDto.Apellido),
                    Password = new Password(usuarioDto.password),
                    PassHash = usuarioDto.passHash,
                    Eliminado = usuarioDto.Eliminado,
                    Discriminator = usuarioDto.Discriminador
                };
            }
        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            string discriminador = "";
            if(usuario is Admin)
            {
                discriminador = "Admin";
            }
            if (usuario is Normal)
            {
                discriminador = "Normal";
            }
            return new UsuarioDto(usuario.Id,usuario.Email.Value,usuario.NombreCompleto.Name,usuario.NombreCompleto.Apellido,usuario.Password.Value, usuario.PassHash,discriminador, usuario.Eliminado);
        }

        public static IEnumerable<UsuarioDto> ToListaDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDto> aux = new List<UsuarioDto>();
            foreach (var user in usuarios)
            {
                UsuarioDto userDto = UsuarioMapper.ToDto(user);
                aux.Add(userDto);
            }
            return aux;
        }
    }
}
