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
    public class EditarUsuario : IEditar<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public EditarUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(int id, UsuarioDto obj)
        {
            Usuario user = UsuarioMapper.FromDto(obj);
            _repoUsuario.Update(id, user);
        }
    }
}
