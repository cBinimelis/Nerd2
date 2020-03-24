using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Pendientes
    {
        public int IdPendiente { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoPendiente { get; set; }

        public virtual TipoPendiente IdTipoPendienteNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
