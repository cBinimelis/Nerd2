using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvanceAnime
    {
        public AvanceAnime()
        {
            AnimeUsuario = new HashSet<AnimeUsuario>();
        }

        public int IdAvanceAnime { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<AnimeUsuario> AnimeUsuario { get; set; }
    }
}
