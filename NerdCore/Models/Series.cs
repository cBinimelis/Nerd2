using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Series
    {
        public Series()
        {
            SerieUsuario = new HashSet<SerieUsuario>();
        }

        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public DateTime Lanzamiento { get; set; }
        public int Temporadas { get; set; }
        public int CapitulosTotales { get; set; }
        public string Imagen { get; set; }
        public int IdGeneroSerie { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoSerie { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }

        public virtual EstadoSerie IdEstadoSerieNavigation { get; set; }
        public virtual GeneroSerie IdGeneroSerieNavigation { get; set; }
        public virtual ICollection<SerieUsuario> SerieUsuario { get; set; }
    }
}
