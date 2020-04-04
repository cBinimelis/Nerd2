using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdCore.Models
{
    public partial class Anime
    {
        public Anime()
        {
            AnimeUsuario = new HashSet<AnimeUsuario>();
        }

        [Key]
        public int IdAnime { get; set; }

        public string Nombre { get; set; }
        public string Sinopsis { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Lanzamiento { get; set; }
        public int Temporadas { get; set; }
        public int CapitulosTotales { get; set; }
        public string Imagen { get; set; }
        public int IdGeneroAnime { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoSerie { get; set; }
        public bool Activo { get; set; }

        public virtual EstadoSerie IdEstadoSerieNavigation { get; set; }
        public virtual GeneroAnime IdGeneroAnimeNavigation { get; set; }
        public virtual ICollection<AnimeUsuario> AnimeUsuario { get; set; }
    }
}
