using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.IO;
using Entidad.Seguridad;

namespace Capa_Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        //static HttpPostedFile file = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string Login(User objUser)
        {
            string respuesta = "";
            respuesta = objUser != null ? "OK" : "BAD";
            return respuesta;
        }

        [WebMethod]
        public static object getUsers()
        {
            List<User> lista = new List<User>();
            lista.Add(new User() { id = 1, user = "Jorge", password = "746" });
            lista.Add(new User() { id = 2, user = "Amelia", password = "741"});
            //string json = JsonConvert.SerializeObject(lista);            
            object json = new { data = lista};

            return json;
        }

    }
}