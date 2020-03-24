using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class VPelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string Duracion { get; set; }
        public string Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string OtrosGeneros { get; set; }
        public string Estado { get; set; }
    }
}
