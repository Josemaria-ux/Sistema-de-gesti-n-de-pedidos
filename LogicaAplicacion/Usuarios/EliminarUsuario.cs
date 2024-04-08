using LogicaAplicacion.Dtos.Usuarios;
using LogicaNegocio.InterfazRepositorio;
using LogicaNegocio.InterfazServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class EliminarUsuario : IEliminar<UsuarioDto>
    {
        IRepositorioUsuario _repoUsuario;

        public EliminarUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void Ejecutar(int id)
        {
            _repoUsuario.Delete(id);
        }
    }
}
