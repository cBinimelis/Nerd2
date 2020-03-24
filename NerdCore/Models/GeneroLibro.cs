using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroLibro
    {
        public GeneroLibro()
        {
            Libros = new HashSet<Libros>();
        }

        public int IdGeneroLibro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
