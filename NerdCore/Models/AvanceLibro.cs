using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvanceLibro
    {
        public AvanceLibro()
        {
            LibroUsuario = new HashSet<LibroUsuario>();
        }

        public int IdAvanceLibro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<LibroUsuario> LibroUsuario { get; set; }
    }
}
