using Datos.Anime;
using Entidad.Anime;
using System.Collections.Generic;

namespace Negocio.Anime
{
    public class AnimeBL
    {
        public static readonly AnimeBL _instancia = new AnimeBL();
        public static AnimeBL Instancia {
            get { return AnimeBL._instancia; }
        }

        public List<AnimeE> listarAnimes()
        {
            return AnimeDAO.Instancia.listarAnimes();
        }
        public bool guardar(AnimeE objAnime)
        {
            bool respuesta = false;
            HistorialAnime objHistorial = null;
            respuesta = AnimeDAO.Instancia.guardar(objAnime);
            if (respuesta)
            {
                objHistorial = new HistorialAnime();
                objHistorial.idanime = objAnime.idanime;
                objHistorial.mensaje = objAnime.nombre;
            }            

            return HistorialAnimeDAO.Instancia.guardar( objHistorial );
        }
    }
}
