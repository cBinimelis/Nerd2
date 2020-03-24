using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Mensajes
    {
        public int IdMensaje { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public int IdEstadoMensaje { get; set; }

        public virtual EstadoMensaje IdEstadoMensajeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
