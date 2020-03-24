using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class VAnime
    {
        public int IdAnime { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string Lanzamiento { get; set; }
        public int Temporadas { get; set; }
        public int Capitulos { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string OtrosGeneros { get; set; }
        public string Estado { get; set; }
    }
}
