using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string connection = "Data Source=.;Initial Catalog=animewolf;Persist Security Info=True;User ID=sa;Password=123456";
            sqlConnection.ConnectionString = connection;
            return sqlConnection;
        }
    }
}
