using LogicaAplicacion.Dtos.MapeosDto;
using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class GetByIdUsuario : IObtener<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public GetByIdUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public UsuarioDto Ejecutar(int Id)
        {
            Usuario user = _repoUsuario.GetById(Id);
            UsuarioDto usuarioDto = UsuarioMapper.ToDto(user);
            return usuarioDto;
        }
    }
}
