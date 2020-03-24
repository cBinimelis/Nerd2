using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Juegos
    {
        public Juegos()
        {
            JuegosUsuario = new HashSet<JuegosUsuario>();
        }

        public int IdJuego { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int IdDesarrollador { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public int IdGeneroJuego { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoJuego { get; set; }
        public bool Activo { get; set; }

        public virtual Desarrollador IdDesarrolladorNavigation { get; set; }
        public virtual EstadoJuegos IdEstadoJuegoNavigation { get; set; }
        public virtual GeneroJuegos IdGeneroJuegoNavigation { get; set; }
        public virtual ICollection<JuegosUsuario> JuegosUsuario { get; set; }
    }
}
