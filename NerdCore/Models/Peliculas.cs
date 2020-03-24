using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Peliculas
    {
        public Peliculas()
        {
            PeliculaUsuario = new HashSet<PeliculaUsuario>();
        }

        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public string Duracion { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public int IdGeneroPelicula { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoPelicula { get; set; }
        public bool Activo { get; set; }

        public virtual EstadoPelicula IdEstadoPeliculaNavigation { get; set; }
        public virtual GeneroPelicula IdGeneroPeliculaNavigation { get; set; }
        public virtual ICollection<PeliculaUsuario> PeliculaUsuario { get; set; }
    }
}
