using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class EstadoLibro
    {
        public EstadoLibro()
        {
            Libros = new HashSet<Libros>();
        }

        public int IdEstadoLibro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
