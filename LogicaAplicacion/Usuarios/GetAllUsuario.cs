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
    public class GetAllUsuario : IObtenerTodos<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public GetAllUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public IEnumerable<UsuarioDto> Ejecutar()
        {
            IEnumerable<UsuarioDto> usuariosDtos = UsuarioMapper.ToListaDto(_repoUsuario.GetAll());
            return usuariosDtos;
        }
    }
}
