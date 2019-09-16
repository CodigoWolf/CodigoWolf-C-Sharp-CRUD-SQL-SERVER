using Entidad.Anime;
using Entidad.Seguridad;
using Negocio.Anime;
using Reportes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Services;

namespace Capa_Presentacion
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string opcion = Convert.ToString(Request.QueryString["exportar"]);
            if (opcion != null)
            {
                ExportarAnimePDF();
            }

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

        public void ExportarAnimePDF()
        {
            var logica = new AnimeBL();
            var lista = logica.listarAnimes();
            var ms = new MemoryStream();
            //Hace vinculación con el reporte de DevExpress
            Geova reporte = new Geova();
            reporte.DataSource = lista;
            using (ms)
            {
                reporte.ExportToPdf(ms);
                Response.Clear();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename=RR_HH - " + lista[0].nombre + ".pdf"));
                Response.AddHeader("custom", string.Format(lista[0].nombre + ".pdf"));
                Response.BinaryWrite(ms.GetBuffer());
                Response.ContentType = "application/pdf";
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