using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class LibroUsuario
    {
        public int IdLibroUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public int IdAvanceLibro { get; set; }
        public string Nota { get; set; }

        public virtual AvanceLibro IdAvanceLibroNavigation { get; set; }
        public virtual Libros IdLibroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
