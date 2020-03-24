using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class MangaUsuario
    {
        public int IdMangaUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdManga { get; set; }
        public int IdAvanceManga { get; set; }
        public string Nota { get; set; }

        public virtual AvanceManga IdAvanceMangaNavigation { get; set; }
        public virtual Manga IdMangaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
