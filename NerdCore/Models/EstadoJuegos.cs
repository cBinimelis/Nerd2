using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoJuegos
    {
        public EstadoJuegos()
        {
            Juegos = new HashSet<Juegos>();
        }

        public int IdEstadoJuegos { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Juegos> Juegos { get; set; }
    }
}
