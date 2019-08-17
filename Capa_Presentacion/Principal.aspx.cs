using Entidad.Anime;
using Entidad.Seguridad;
using Negocio.Anime;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace Capa_Presentacion
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuario objUsuario = (Usuario)Session["usuario"];
                string user = objUsuario.usuario;
                lblUsuario.Text = user;
            }
            catch (Exception ex)
            {
                Response.Redirect("Index.aspx");
                //throw ex;
            }
        }

        [WebMethod]
        public static object getAnimes()
        {
            List<AnimeE> lista = AnimeBL.Instancia.listarAnimes();         
            object json = new { data = lista };
            return json;
        }

        [WebMethod]
        public static object addAnime( AnimeE objAnime )
        {
            bool respuesta = AnimeBL.Instancia.guardar(objAnime);
            var informacion = "";
            informacion = respuesta? "Se guardaron los datos." : "No se guardaron los datos";
            return new { mensaje = informacion };
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Index.aspx");
        }
    }
}