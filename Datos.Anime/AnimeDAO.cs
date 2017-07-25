using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Seguridad;
using Entidad.Anime;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Anime
{
    public class AnimeDAO
    {
        public static readonly AnimeDAO _instancia = new AnimeDAO();
        public static AnimeDAO Instancia{
            get { return AnimeDAO._instancia; }
        }
        public List<AnimeE> listarAnimes()
        {
            SqlConnection cn = Connection.Instancia.getConnection();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<AnimeE> Lista = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand("listarAnimes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@prm_id", idanime);
                dr = cmd.ExecuteReader();
                Lista = new List<AnimeE>();
                while (dr.Read())
                {
                    Genero objGenero = new Genero() {
                        idgenero = Convert.ToInt32(dr["idgenero"]),
                        nombre = dr["genero"].ToString()//genero alias desde el PROC
                    };
                    AnimeE c = new AnimeE()
                    {
                        idanime = Convert.ToInt32( dr["idanime"] ),
                        nombre = dr["nombre"].ToString(),
                        sinopsis = dr["sinopsis"].ToString(),
                        objGenero = objGenero
                    };
                    Lista.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw ex;//Console.Write("Excepción en AnimeDAO: ", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Lista;
        }

        public bool guardar(AnimeE objAnime)
        {
            SqlConnection cn = Connection.Instancia.getConnection();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            bool respuesta = false;

            try
            {
                cn.Open();
                cmd = new SqlCommand("registrarAnime", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", objAnime.nombre);
                cmd.Parameters.AddWithValue("@sinopsis", objAnime.sinopsis);
                cmd.Parameters.AddWithValue("@estado", objAnime.estado);
                cmd.Parameters.AddWithValue("@idgenero", objAnime.objGenero.idgenero);
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
