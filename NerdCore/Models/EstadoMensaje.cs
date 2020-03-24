using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoMensaje
    {
        public EstadoMensaje()
        {
            Mensajes = new HashSet<Mensajes>();
        }

        public int IdEstadoMensaje { get; set; }
        public string EstadoMensaje1 { get; set; }

        public virtual ICollection<Mensajes> Mensajes { get; set; }
    }
}
