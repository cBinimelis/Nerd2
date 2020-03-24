using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvanceJuego
    {
        public AvanceJuego()
        {
            JuegosUsuario = new HashSet<JuegosUsuario>();
        }

        public int IdAvanceJuego { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<JuegosUsuario> JuegosUsuario { get; set; }
    }
}
