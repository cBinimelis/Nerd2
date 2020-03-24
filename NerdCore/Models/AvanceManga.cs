using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class AvanceManga
    {
        public AvanceManga()
        {
            MangaUsuario = new HashSet<MangaUsuario>();
        }

        public int IdAvanceManga { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<MangaUsuario> MangaUsuario { get; set; }
    }
}
