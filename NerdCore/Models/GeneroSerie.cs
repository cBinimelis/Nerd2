using System;
using System.Collections.Generic;

namespace NerdCore.Models
{
    public partial class GeneroSerie
    {
        public GeneroSerie()
        {
            Series = new HashSet<Series>();
        }

        public int IdGeneroSerie { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Series> Series { get; set; }
    }
}
