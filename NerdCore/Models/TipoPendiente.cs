using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class TipoPendiente
    {
        public TipoPendiente()
        {
            Pendientes = new HashSet<Pendientes>();
        }

        public int IdTipoPendiente { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Pendientes> Pendientes { get; set; }
    }
}
