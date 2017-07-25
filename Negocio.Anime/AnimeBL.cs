using Datos.Anime;
using Entidad.Anime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return AnimeDAO.Instancia.guardar(objAnime);
        }
    }
}
