using Entidad.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Seguridad
{
    public class UsuarioDAO
    {
        private static readonly UsuarioDAO _instancia = new UsuarioDAO();
        public static UsuarioDAO Instancia { get { return UsuarioDAO._instancia; } }

        public Usuario iniciarSesion(Usuario objUsuario)
        {
            SqlConnection cn = Connection.Instancia.getConnection();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Usuario usuario = null;
            try { 
                cn.Open();
                cmd = new SqlCommand("verificarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", objUsuario.usuario);
                cmd.Parameters.AddWithValue("@password", objUsuario.password);
                dr = cmd.ExecuteReader();

                if( dr.HasRows )//verificamos si tiene alguna fila
                {
                    usuario = new Usuario();
                    while (dr.Read())
                    {
                        usuario.idusuario = Convert.ToInt32(dr["idusuario"]);
                        usuario.usuario = dr["usuario"].ToString();
                        usuario.password = dr["password"].ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return usuario;
        }
    }
}
