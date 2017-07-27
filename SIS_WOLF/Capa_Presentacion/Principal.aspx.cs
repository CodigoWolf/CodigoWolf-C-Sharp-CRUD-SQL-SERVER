using Entidad.Anime;
using Negocio.Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_Presentacion
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}