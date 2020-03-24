using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroAnime
    {
        public GeneroAnime()
        {
            Anime = new HashSet<Anime>();
        }

        public int IdGeneroAnime { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Anime> Anime { get; set; }
    }
}
