using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroMangas
    {
        public GeneroMangas()
        {
            Manga = new HashSet<Manga>();
        }

        public int IdGeneroManga { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Manga> Manga { get; set; }
    }
}
