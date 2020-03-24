using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Manga
    {
        public Manga()
        {
            MangaUsuario = new HashSet<MangaUsuario>();
        }

        public int IdManga { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public DateTime Lanzamiento { get; set; }
        public int Tomos { get; set; }
        public string Imagen { get; set; }
        public int IdGeneroManga { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoManga { get; set; }
        public bool? Activo { get; set; }

        public virtual EstadoManga IdEstadoMangaNavigation { get; set; }
        public virtual GeneroMangas IdGeneroMangaNavigation { get; set; }
        public virtual ICollection<MangaUsuario> MangaUsuario { get; set; }
    }
}
