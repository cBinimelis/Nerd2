using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvancePelicula
    {
        public AvancePelicula()
        {
            PeliculaUsuario = new HashSet<PeliculaUsuario>();
        }

        public int IdAvancePelicula { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PeliculaUsuario> PeliculaUsuario { get; set; }
    }
}
