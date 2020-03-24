using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoUsuario
    {
        public EstadoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdEstadoUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
