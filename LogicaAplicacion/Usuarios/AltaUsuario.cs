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
    public class AltaUsuario : IAlta<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public AltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(UsuarioDto obj)
        {
            Usuario user = UsuarioMapper.FromDto(obj);
            _repoUsuario.Add(user);
        }
    }
}
