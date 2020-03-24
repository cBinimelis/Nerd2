using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class VPendientes
    {
        public int IdPendiente { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Tipo { get; set; }
        public int IdTipoPendiente { get; set; }
    }
}
