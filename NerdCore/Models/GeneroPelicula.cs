using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroPelicula
    {
        public GeneroPelicula()
        {
            Peliculas = new HashSet<Peliculas>();
        }

        public int IdGeneroPelicula { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
