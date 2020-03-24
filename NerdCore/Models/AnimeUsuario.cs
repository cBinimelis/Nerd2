using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AnimeUsuario
    {
        public long IdAnimeUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdAnime { get; set; }
        public int IdAvanceAnime { get; set; }
        public string Nota { get; set; }

        public virtual Anime IdAnimeNavigation { get; set; }
        public virtual AvanceAnime IdAvanceAnimeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
