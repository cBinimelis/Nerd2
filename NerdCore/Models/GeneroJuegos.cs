using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroJuegos
    {
        public GeneroJuegos()
        {
            Juegos = new HashSet<Juegos>();
        }

        public int IdGeneroJuego { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Juegos> Juegos { get; set; }
    }
}
