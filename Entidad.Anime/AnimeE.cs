using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Anime
{
    public class AnimeE
    {
        public int idanime { get; set; }
        public string nombre { get; set; }
        public string  sinopsis { get; set; }
        public Int16 estado { get; set; }
        public Genero objGenero { get; set; }
    }
}
