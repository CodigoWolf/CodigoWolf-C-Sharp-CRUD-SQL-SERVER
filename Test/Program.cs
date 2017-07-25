using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Seguridad;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string cn = Connection.Instancia.getConnection();
        }
    }
}
