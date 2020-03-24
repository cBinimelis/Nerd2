using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class VJuegos
    {
        public int IdJuego { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int IdDesarrollador { get; set; }
        public string Desarrollador { get; set; }
        public string Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public string Genero { get; set; }
        public string OtrosGeneros { get; set; }
        public string Estado { get; set; }
    }
}
