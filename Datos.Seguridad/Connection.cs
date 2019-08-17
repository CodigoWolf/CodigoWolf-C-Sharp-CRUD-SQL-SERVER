using System.Data.SqlClient;

namespace Datos.Seguridad
{
    public class Connection
    {
        private static readonly Connection _instancia = new Connection();
        public static Connection Instancia
        {
            get { return Connection._instancia; }
        }
        public SqlConnection getConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            string connection = "Data Source=.;Initial Catalog=animewolf;Integrated Security=True";
            //string connection = "Data Source=.;Initial Catalog=animewolf;Persist Security Info=True;User ID=sa;Password=123456";
            sqlConnection.ConnectionString = connection;
            return sqlConnection;
        }
    }
}
