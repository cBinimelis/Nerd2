using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libros>();
        }

        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
