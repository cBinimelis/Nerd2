using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoManga
    {
        public EstadoManga()
        {
            Manga = new HashSet<Manga>();
        }

        public int IdEstadoManga { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Manga> Manga { get; set; }
    }
}
