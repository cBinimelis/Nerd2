using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class PeliculaUsuario
    {
        public int IdPeliculaUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPelicula { get; set; }
        public int IdAvancePelicula { get; set; }
        public string Nota { get; set; }

        public virtual AvancePelicula IdAvancePeliculaNavigation { get; set; }
        public virtual Peliculas IdPeliculaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
