using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Desarrollador
    {
        public Desarrollador()
        {
            Juegos = new HashSet<Juegos>();
        }

        public int IdDesarrollador { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Juegos> Juegos { get; set; }
    }
}
