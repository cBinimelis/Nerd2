using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvanceSerie
    {
        public AvanceSerie()
        {
            SerieUsuario = new HashSet<SerieUsuario>();
        }

        public int IdAvanceSerie { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SerieUsuario> SerieUsuario { get; set; }
    }
}
