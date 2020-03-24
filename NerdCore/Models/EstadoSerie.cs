using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoSerie
    {
        public EstadoSerie()
        {
            Anime = new HashSet<Anime>();
            Series = new HashSet<Series>();
        }

        public int IdEstadoSerie { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Anime> Anime { get; set; }
        public virtual ICollection<Series> Series { get; set; }
    }
}
