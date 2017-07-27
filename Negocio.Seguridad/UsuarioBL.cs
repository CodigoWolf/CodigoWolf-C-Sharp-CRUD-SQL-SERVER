using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Seguridad;
using Entidad.Seguridad;

namespace Negocio.Seguridad
{
    public class UsuarioBL
    {
        private static readonly UsuarioBL _instancia = new UsuarioBL();
        public static UsuarioBL Instancia {
            get { return UsuarioBL._instancia; }
        }
        public Usuario iniciarSesion(Usuario objUsuario)
        {
            return UsuarioDAO.Instancia.iniciarSesion(objUsuario);
        }
    }
}
