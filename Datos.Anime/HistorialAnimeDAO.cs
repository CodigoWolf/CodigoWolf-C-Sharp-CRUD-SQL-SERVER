using Datos.Seguridad;
using Entidad.Anime;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Anime
{
    public class HistorialAnimeDAO
    {
        public static readonly HistorialAnimeDAO _instancia = new HistorialAnimeDAO();
        public static HistorialAnimeDAO Instancia
        {
            get { return HistorialAnimeDAO._instancia; }
        }

        public bool guardar(HistorialAnime objHistorial)
        {
            SqlConnection cn = Connection.Instancia.getConnection();
            SqlCommand cmd = null;
            bool respuesta = false;

            try
            {
                cmd = new SqlCommand("registrarHistorialAnime", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idanime", objHistorial.idanime);
                cmd.Parameters.AddWithValue("@mensaje", objHistorial.mensaje);

                cn.Open();
                int fila = cmd.ExecuteNonQuery();
                if (fila > 0)
                {
                    respuesta = true;
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

            return respuesta;

        }
    }
}
