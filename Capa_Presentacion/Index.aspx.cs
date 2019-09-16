using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.IO;
using Entidad.Seguridad;
using Negocio.Seguridad;

namespace Capa_Presentacion
{
    public partial class Index : System.Web.UI.Page
    {
        //static HttpPostedFile file = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }        

        [WebMethod]
        public static object Login(Usuario objUsuario)
        {
            /*Usuario usuario = UsuarioBL.Instancia.iniciarSesion(objUsuario);
            
            object respuesta = "";
            respuesta = usuario != null ? "Principal.aspx" : "BAD";
            return new { mensaje = respuesta */
            return "";
        }

        [WebMethod]
        public static object getUsers()
        {
            List<Usuario> lista = new List<Usuario>();
            lista.Add(new Usuario() { idusuario = 1, usuario = "Jorge", password = "746" });
            lista.Add(new Usuario() { idusuario = 2, usuario = "Amelia", password = "741"});
            //string json = JsonConvert.SerializeObject(lista);            
            object json = new { data = lista};

            return json;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario() {
                idusuario = 0,
                usuario = Request["usuario"],
                password = Request["password"]
            };
            Usuario usuario = UsuarioBL.Instancia.iniciarSesion(objUsuario);
                        
            if( usuario != null)
            {
                Session["usuario"] = usuario;
                Response.Redirect("Principal.aspx");
            }else
            {
                //poner un label
                lblMensaje.Text = "Usuario y Password incorrectos";
            }
            
        }
    }
}