using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class VLibros
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int Paginas { get; set; }
        public int IdAutor { get; set; }
        public string Autor { get; set; }
        public string Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string OtrosGeneros { get; set; }
        public string Estado { get; set; }
    }
}
