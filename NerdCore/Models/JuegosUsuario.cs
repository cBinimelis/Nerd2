using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class JuegosUsuario
    {
        public int IdJuegoUsuario { get; set; }
        public int IdJuego { get; set; }
        public int IdUsuario { get; set; }
        public int IdAvanceJuego { get; set; }
        public string Nota { get; set; }

        public virtual AvanceJuego IdAvanceJuegoNavigation { get; set; }
        public virtual Juegos IdJuegoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
