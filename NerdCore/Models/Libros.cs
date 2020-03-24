using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class Libros
    {
        public Libros()
        {
            LibroUsuario = new HashSet<LibroUsuario>();
        }

        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int Paginas { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string Imagen { get; set; }
        public int IdAutor { get; set; }
        public int IdGeneroLibro { get; set; }
        public string OtrosGeneros { get; set; }
        public int IdEstadoLibro { get; set; }
        public bool Activo { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual GeneroLibro IdEstadoLibro1 { get; set; }
        public virtual EstadoLibro IdEstadoLibroNavigation { get; set; }
        public virtual ICollection<LibroUsuario> LibroUsuario { get; set; }
    }
}
