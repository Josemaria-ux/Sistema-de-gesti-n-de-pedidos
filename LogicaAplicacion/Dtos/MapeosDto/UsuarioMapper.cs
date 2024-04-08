using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
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
            return new Normal()
            {
                Email = new Email(usuarioDto.Email),
                NombreCompleto = new NombreUsuario(usuarioDto.Nombre, usuarioDto.Apellido),
                Password = new Password(usuarioDto.password)
            };
        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto(usuario.Id,usuario.Email.Value,usuario.NombreCompleto.Name,usuario.NombreCompleto.Apellido,usuario.Password.Value);
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
