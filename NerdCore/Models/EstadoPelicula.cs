using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoPelicula
    {
        public EstadoPelicula()
        {
            Peliculas = new HashSet<Peliculas>();
        }

        public int IdEstadoPelicula { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
