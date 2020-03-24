using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class SerieUsuario
    {
        public int IdSerieUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdSerie { get; set; }
        public int IdAvanceSerie { get; set; }
        public string Nota { get; set; }

        public virtual AvanceSerie IdAvanceSerieNavigation { get; set; }
        public virtual Series IdSerieNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
