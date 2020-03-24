using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripción { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
